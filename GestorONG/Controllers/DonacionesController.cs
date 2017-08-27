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

namespace GestorONG.Controllers
{
    public class DonacionesController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        // GET: Donaciones
        public ActionResult Index()
        {
            var donaciones = db.donaciones.Include(d => d.colaboradores).Include(d => d.periodicidades);
            return View(donaciones.ToList());
        }

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
                /* var persona = db.persona.Find(modelo.donacion.idColaborador);

                 db.Entry(persona).State = EntityState.Detached;
                 var colaborador = new colaboradores(persona,modelo.NIF,modelo.cuentaBancaria);

                 colaborador.personas = persona;
                 colaborador.idColaborador = persona.id;
                 //db.colaboradores.Add(colaborador);
                 db.Entry(colaborador).State = EntityState.Modified;
                 //db.Entry(persona).State = EntityState.Unchanged;

                 db.SaveChanges();*/

                var existingcolaborador = db.colaboradores.Where(x => x.id == modelo.donacion.idColaborador).FirstOrDefault();
                existingcolaborador.idColaborador = modelo.donacion.idColaborador;
                existingcolaborador.CIF_NIF = modelo.NIF;
                existingcolaborador.CuentaBancaria = modelo.cuentaBancaria;
                db.Entry(existingcolaborador).State = EntityState.Modified;

                // Añadir la relación entre personas y perfiles en la tabla personas_perfiles
                var personas_perfiles = new personas_perfiles(0, modelo.donacion.idColaborador, 2);
                db.persona_perfil.Add(personas_perfiles);
                db.SaveChanges();
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
