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
using System.Data.Entity.Core.Objects;
using GestorONG.Models;
using Newtonsoft.Json;

namespace GestorONG.Controllers
{
    public class VoluntariosController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        #region INDEX_METHODS

        // GET: Voluntarios
        public ActionResult Index()
        {
            return View(db.voluntario.ToList());
        }

        /// <summary>
        /// Load data from server.
        /// </summary>
        /// <returns>List of collaborators to show in JQuery Datatable.</returns>
        [HttpPost]
        [Authorize]
        public ActionResult LoadData()
        {
            string state = "";
            string country = "";
            string location = "";

            string draw = "";
            int start = 0;
            int length = 0;
            int totalRecords = 0;
            int recordsFiltered = 0;
            //To save collaborator filtered.
            IQueryable<voluntario> volunteers;
            try
            {
                var search = Request["search[value]"];
                //jQuery DataTables Param
                draw = Request.Form.GetValues("draw").FirstOrDefault();
                //Find paging info
                start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
                length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());

                //Filter
                state = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();
                country = Request.Form.GetValues("columns[7][search][value]").FirstOrDefault();
                location = Request.Form.GetValues("columns[13][search][value]").FirstOrDefault();


                //Sort
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][data]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();



                volunteers = new VolunteersRepository().GetPaginated(search, start, length, out totalRecords, out recordsFiltered, sortColumn,
                    sortColumnDir, state, country, location);
            }
            catch (Exception)
            {
                volunteers = db.voluntario.AsQueryable();
                recordsFiltered = volunteers.Count();
                totalRecords = recordsFiltered;
            }
            //Returning Json Data
            var jsonResult = Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = totalRecords, data = volunteers });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// Retrieve unique values for each filter field.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public string GetSelectData()
        {
            Dictionary<string, List<object>> jsonToSerialize = new Dictionary<string, List<object>>();

            //State
            IQueryable<object> values = db.voluntario.Select(x => x.provincia).Distinct();
            jsonToSerialize.Add("State", values.ToList());

            //Country
            values = db.voluntario.Select(x => x.pais).Distinct();
            jsonToSerialize.Add("Country", values.ToList());

            //Location
            values = db.voluntario.Select(x => x.Sede.ToString()).Distinct();
            jsonToSerialize.Add("Location", values.ToList());

            //Periodicity

            string jsonSerialized = JsonConvert.SerializeObject(jsonToSerialize, Formatting.Indented);

            return jsonSerialized;
        }

        // GET: Voluntarios/listadoVoluntarios
        [HttpGet]
        public JsonResult listadoVoluntarios()
        {
            var jsonData = new
            {
                data = from vol in db.voluntario.ToList() select vol
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // GET: Voluntarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voluntario voluntario = db.voluntario.FirstOrDefault(m => m.id == id);
            if (voluntario == null)
            {
                return HttpNotFound();
            }
            return View(voluntario);
        }

        // GET: Voluntarios/Create
        public ActionResult Create()
        {
            // Preparo la vista con los dropdown

            var delegaciones = db.sedes_delegaciones.ToList().Select(x => new SelectListItem
            {
                Text = x.nombre,
                Value = x.nombre
            });
            ViewBag.Delegaciones = delegaciones;
            
            return View();
        }

        // POST: Voluntarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidos,direccionPostal,codigoPostal,localidad,provincia,pais,telefono1,telefono2,email,fechaNacimiento,fechaAlta,Sede,Perfiles")] voluntario model)
        {
            if (ModelState.IsValid)
            {

                //Get id of sede_name
                var sedes = db.sedes_delegaciones.SingleOrDefault(i => i.nombre == model.Sede);

                //Convert date
                var fecha = Convert.ToDateTime(model.fechaNacimiento);

                //Profile id is 1 for Voluntarios
                //Transform voluntario class in voluntarios class to allow insert, updating, deleting
                //Insert a new volunteer through voluntarios table
                var voluntariosNuevo = new voluntarios(0, model.nombre, model.apellidos, model.direccionPostal, model.codigoPostal, model.localidad, model.provincia, model.pais,
                    model.telefono1, model.telefono2, model.email, fecha, model.fechaAlta, sedes.id);
                db.voluntarios.Add(voluntariosNuevo);
                db.SaveChanges();

                //Insert the relationship many to many in personas_perfiles
                var perPerfilNew = new personas_perfiles(0, voluntariosNuevo.id, 1);
                db.persona_perfil.Add(perPerfilNew);
                db.SaveChanges();
                TempData["Acierto"] = "El voluntario/a " + model.nombre + " " + model.apellidos + " ha sido añadido/a correctamente al sistema.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Voluntarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voluntario voluntario = db.voluntario.FirstOrDefault(m => m.id == id);
            if (voluntario == null)
            {
                return HttpNotFound();
            }
            var delegaciones = db.sedes_delegaciones.ToList().Select(x => new SelectListItem
            {
                Text = x.nombre,
                Value = x.nombre
            });
            ViewBag.Delegaciones = delegaciones;

            return View(voluntario);
        }

        // POST: Voluntarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellidos,direccionPostal,codigoPostal,localidad,provincia,pais,telefono1,telefono2,email,fechaNacimiento,fechaAlta,Sede,Perfiles")] voluntario voluntario)
        {
            if (ModelState.IsValid)
            {
                // Change default behaviour to allow modifiy entity by entity
                //Get id of sede_name
                var sedes = db.sedes_delegaciones.SingleOrDefault(i => i.nombre == voluntario.Sede);

                //Convert date
                var fecha = Convert.ToDateTime(voluntario.fechaNacimiento);

                //Transform voluntario class in voluntarios class to allow insert, updating, deleting
                //Insert a new volunteer through voluntarios table
                var voluntariosActualizado = new voluntarios(voluntario.id,voluntario.nombre,voluntario.apellidos,voluntario.direccionPostal,voluntario.codigoPostal,voluntario.localidad,
                    voluntario.provincia,voluntario.pais,voluntario.telefono1,voluntario.telefono2,voluntario.email,fecha,voluntario.fechaAlta,sedes.id);
                db.Entry(voluntariosActualizado).State = EntityState.Modified;
               db.SaveChanges();
                //It is no needed to update personas_perfiles because now, we do not allow to modify the profile
                TempData["Acierto"] = "El voluntario/a " + voluntario.nombre + " " + voluntario.apellidos + " ha sido editado correctamente.";
                return RedirectToAction("Index");
            }
            return View(voluntario);
        }

        // GET: Voluntarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            voluntario voluntario = db.voluntario.FirstOrDefault(m => m.id == id);
            if (voluntario == null)
            {
                return HttpNotFound();
            }
            return View(voluntario);
        }

        // POST: Voluntarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Para vistas usar Single or default
            // Get voluntarios item
            voluntarios voluntario = db.voluntarios.SingleOrDefault(m => m.id == id);

            //Also needed to delete from personas_perfiles
            personas_perfiles per = db.persona_perfil.SingleOrDefault(m => m.idPersona == id && m.idPerfil == 1);
            db.persona_perfil.Remove(per);
            db.SaveChanges();

            TempData["Acierto"] = "El voluntario/a " + voluntario.nombre + " " + voluntario.apellidos + " ha sido eliminada del sistema correctamente.";

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
    }
}
