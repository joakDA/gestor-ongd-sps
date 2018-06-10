using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestorONG.DAL;
using GestorONG.DataModel;
using GestorONG.ViewModel;
using GestorONG.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace GestorONG.Controllers
{
    [Authorize]
    public class DonacionesController : Controller
    {
        #region PRIVATE_MEMBER_PROPERTIES

        private GestorONGDContext db = new GestorONGDContext();

        #endregion

        #region INDEX_METHODS

        // GET: Donaciones
        public ActionResult Index()
        {
            List<DonationsViewModel> donations = ConvertDonationsFromDBToView(db.donaciones.Include(x => x.colaboradores).Include(x => x.periodicidades).ToList());
            return View(donations);
        }

        /// <summary>
        /// Load data from server.
        /// </summary>
        /// <returns>List of collaborators to show in JQuery Datatable.</returns>
        [HttpPost]
        public ActionResult LoadData()
        {
            JsonResult jsonResult;
            Single amount;
            string nif = "";
            string collaborator = "";
            string periodicity = "";

            string draw = "";
            int start = 0;
            int length = 0;
            int totalRecords = 0;
            int recordsFiltered = 0;
            //To save collaborator filtered.
            IQueryable<donaciones> donations;
            try
            {
                var search = Request["search[value]"];
                //jQuery DataTables Param
                draw = Request.Form.GetValues("draw").FirstOrDefault();
                //Find paging info
                start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
                length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());

                //Filter
                string amountStr = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
                Single.TryParse(amountStr, NumberStyles.Any, CultureInfo.InvariantCulture, out amount);
                nif = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
                collaborator = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
                periodicity = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();

                //Sort
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][data]").FirstOrDefault();
                sortColumn = ConvertSortColumn(sortColumn);
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

                donations = new DonationsRepository().GetPaginated(search, start, length, out totalRecords, out recordsFiltered, sortColumn,
                    sortColumnDir, amount, nif, collaborator, periodicity);
            }
            catch (Exception)
            {
                donations = db.donaciones.AsQueryable();
                recordsFiltered = donations.Count();
                totalRecords = recordsFiltered;
            }

            List<DonationsViewModel> viewData = ConvertDonationsFromDBToView(donations.ToList());
            //Returning Json Data
            jsonResult = Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = totalRecords, data = viewData });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// Retrieve unique values for each filter field.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string GetSelectData()
        {
            Dictionary<string, List<object>> jsonToSerialize = new Dictionary<string, List<object>>();

            //Amounts
            IQueryable<object> values = db.donaciones.Select(x => x.cantidad.ToString()).Distinct();
            jsonToSerialize.Add("Amount", values.ToList());

            //NIF
            values = db.colaboradores.Select(x => x.CIF_NIF).Distinct();
            jsonToSerialize.Add("NIF", values.ToList());

            //Collaborator
            values = db.colaboradores.Select(x => x.nombre + " " + x.apellidos).Distinct();
            jsonToSerialize.Add("Collaborator", values.ToList());

            //Periodicity
            values = db.periodicidades.Select(x => x.nombre).Distinct();
            jsonToSerialize.Add("Periodicity", values.ToList());

            string jsonSerialized = JsonConvert.SerializeObject(jsonToSerialize, Formatting.Indented);

            return jsonSerialized;
        }

        /// <summary>
        /// Convert a list of <c>donaciones</c> with data retrieved from database to a list of <c>DonationsViewModel</c> to display data on view.
        /// </summary>
        /// <param name="list">List of <c>donaciones</c> with data retrieved from database.</param>
        /// <returns>List of <c>DonationsViewModel</c> with data to show on view.</returns>
        private List<DonationsViewModel> ConvertDonationsFromDBToView(List<donaciones> list)
        {
            List<DonationsViewModel> result = list.Select(item => new DonationsViewModel()
            {
                id = item.id,
                amount = item.cantidad,
                donationDate = item.fechaAlta,
                bankAccount = item.colaboradores.CuentaBancaria,
                NIF = item.colaboradores.CIF_NIF,
                collaborator = string.Format("{0} {1}", item.colaboradores.nombre, item.colaboradores.apellidos),
                periodicity = item.periodicidades.nombre
            }).ToList();

            return result;
        }

        /// <summary>
        /// Convert sortColumn from <c>DonationsViewModel</c> property name to <c>donaciones</c> property name to make sorting work.
        /// </summary>
        /// <param name="sortColumn">sortColumn from <c>DonationsViewModel</c> property name</param>
        /// <returns>sortColumn from <c>donaciones</c> property name</returns>
        private string ConvertSortColumn(string sortColumn)
        {
            string sResult = "";

            switch (sortColumn)
            {
                case "amount":
                    sResult = "cantidad";
                    break;
                case "donationDate":
                    sResult = "fechaAlta";
                    break;
                default:
                    sResult = "id";
                    break;
            }

            return sResult;
        }

        #endregion

        // GET: Donaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donaciones donacion = db.donaciones.Find(id);
            // Se recuperan los datos del colaborador
            vistaColaboradores colaborador = db.vistaColaboradores.SingleOrDefault(x => x.id == donacion.idColaborador);
            // Se crea el viewmodel a partir de los datos anteriores
            DonacionesViewModel modelo = new DonacionesViewModel(donacion, colaborador.CuentaBancaria, colaborador.CIF_NIF);
            if (donacion == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // GET: Donaciones/Create
        public ActionResult Create()
        {
            var colaboradores = getColaboradoresSelectList();
            
            ViewBag.idColaborador = colaboradores;
            ViewBag.idPeriodicidad = new SelectList(db.periodicidades, "id", "nombre");
            return View();
        }

        // POST: Donaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DonacionesViewModel modelo)
        {
            
            //modelo.donacion.colaboradores = new colaboradores(db.persona.Where(x => x.id == modelo.donacion.idColaborador).First();
            if (ModelState.IsValid)
            {
                // Se crea la donación en la base de datos.
                db.donaciones.Add(modelo.donacion);
                db.SaveChanges();
                // Añadir al colaborador en la tabla de colaboradores.
                
                /*persona.colaboradores.Add(colaborador);
                persona.colaboradores.First().CIF_NIF = modelo.NIF;
                persona.colaboradores.First().CuentaBancaria = modelo.cuentaBancaria;
                 db.Entry(persona).State = EntityState.Modified;

                 db.SaveChanges();*/
                 using (var context = new GestorONGDContext())
                {
                    var persona = context.persona.Find(modelo.donacion.idColaborador);
                    var colaborador = new colaboradores(persona, modelo.NIF, modelo.cuentaBancaria);

                    personas_perfiles per_perfiles = new personas_perfiles()
                    {
                        idPersona = modelo.donacion.idColaborador,
                        idPerfil = 2
                        //personas = colaborador
                    };
                    /*persona.colaboradores = new HashSet<colaboradores>();
                    persona.colaboradores.Add(colaborador);*/
                    /*var colaborador = new colaboradores()
                    {
                        CIF_NIF = modelo.NIF,
                        CuentaBancaria = modelo.cuentaBancaria
                    };*/
                    context.colaboradores.Add(colaborador);
                    context.SaveChanges();
                    colaborador.idColaborador = modelo.donacion.idColaborador;
                    context.Entry(colaborador).State = EntityState.Modified;
                    context.persona.Remove(persona);
                    context.persona_perfil.Add(per_perfiles);
                    context.SaveChanges();
                }
                //db.Entry(persona).State = EntityState.Detached;
                
                /*var existingcolaborador = db.colaboradores.Where(x => x.id == modelo.donacion.idColaborador).FirstOrDefault();
                existingcolaborador.idColaborador = modelo.donacion.idColaborador;
                existingcolaborador.CIF_NIF = modelo.NIF;
                existingcolaborador.CuentaBancaria = modelo.cuentaBancaria;
                db.Entry(existingcolaborador).State = EntityState.Modified;

                // Añadir la relación entre personas y perfiles en la tabla personas_perfiles
                var personas_perfiles = new personas_perfiles(0, modelo.donacion.idColaborador, 2);
                db.persona_perfil.Add(personas_perfiles);
                db.SaveChanges();*/
                //TempData["Acierto"] = "La donación creada por el colaborador " + persona.nombre + " " + persona.apellidos + " con un valor de " + modelo.donacion.cantidad + "€ ha sido realizada correctamente";




                return RedirectToAction("Index");
            }else
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                Console.Write(errors.ToString());
            }

            // Se listan las personas que no son colaboradores existentes en el sistema puesto que sólo se puede hacer una única donación por usuario.
            var colaboradores = getColaboradoresSelectList();

            ViewBag.idColaborador = colaboradores;
            ViewBag.idPeriodicidad = new SelectList(db.periodicidades, "id", "nombre", modelo.donacion.idPeriodicidad);
            return View(modelo);
        }

        // GET: Donaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donaciones donacion = db.donaciones.Find(id);
            // Se recuperan los datos del colaborador
            vistaColaboradores colaborador = db.vistaColaboradores.SingleOrDefault(x => x.id == donacion.idColaborador);
            // Se crea el viewmodel a partir de los datos anteriores
            DonacionesViewModel modelo = new DonacionesViewModel(donacion, colaborador.CuentaBancaria,colaborador.CIF_NIF);
            if (donacion == null)
            {
                return HttpNotFound();
            }
            // Se cargan los desplegables con datos
            ViewBag.colaborador = colaborador.nombre + " " + colaborador.apellidos;
            ViewBag.idPeriodicidad = new SelectList(db.periodicidades, "id", "nombre", donacion.idPeriodicidad);
            return View(modelo);
        }

        // POST: Donaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DonacionesViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model.donacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Se recuperan los datos del colaborador
            vistaColaboradores colaborador = db.vistaColaboradores.SingleOrDefault(x => x.id == model.donacion.idColaborador);
            ViewBag.colaborador = colaborador.nombre + " " + colaborador.apellidos;
            // Se cargan los desplegables con datos
            ViewBag.idPeriodicidad = new SelectList(db.periodicidades, "id", "nombre", model.donacion.idPeriodicidad);
            return View(model);
        }

        // GET: Donaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donaciones donacion = db.donaciones.Find(id);
            // Se recuperan los datos del colaborador
            vistaColaboradores colaborador = db.vistaColaboradores.SingleOrDefault(x => x.id == donacion.idColaborador);
            // Se crea el viewmodel a partir de los datos anteriores
            DonacionesViewModel modelo = new DonacionesViewModel(donacion, colaborador.CuentaBancaria, colaborador.CIF_NIF);
            if (donacion == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Donaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Se elimina la donación
            donaciones donaciones = db.donaciones.Find(id);
            db.donaciones.Remove(donaciones);
            // Se elimina al colaborador de la tabla personas_perfiles
            personas_perfiles per = db.persona_perfil.Where(m => m.idPersona == donaciones.idColaborador && m.idPerfil == 2).SingleOrDefault();
            db.persona_perfil.Remove(per);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #region PRIVATE_MEMBER_METHODS

        /// <summary>
        /// Devuelve una lista para crear un desplegable con el nombre y apellidos de las personas existentes en el sistema.
        /// </summary>
        /// <returns>IQueriable<SelectListItem> lista para construir el dropwdown con los candidatos a ser colaboradores.</returns>
        private object getColaboradoresSelectList()
        {
            // Sólo las personas que estén en colaboradores en la tabla personas_perfiles
            //List<personas> posiblesColaboradores = db.persona.Where(p => p.personas_perfiles.Where(x => x.idPersona == p.id && x.perfiles.nombre == "Colaborador").Any()).ToList();
            // Se listan las personas que no son colaboradores existentes en el sistema puesto que sólo se puede hacer una única donación por usuario.
            var perfil = db.perfil.SingleOrDefault(m => m.nombre == "Colaborador");
            var posiblesColaboradores = db.persona.Where(u => !u.personas_perfiles.Any(r => r.idPerfil == perfil.id));

            var colaboradores = posiblesColaboradores.Select(x => new SelectListItem
            {
                Text = x.nombre + " " + x.apellidos,
                Value = x.id.ToString()
            });

            return colaboradores;
        }

        #endregion
    }
}
