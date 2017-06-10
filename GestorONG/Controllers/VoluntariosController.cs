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
    public class VoluntariosController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        // GET: Voluntarios
        public ActionResult Index()
        {
            return View(db.voluntario.ToList());
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

        // GET: Voluntarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voluntario voluntario = db.voluntario.SingleOrDefault(m => m.id == id);
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
            var model = new VoluntariosViewModel();

            model.vol = new voluntario();
            model.delegacion = db.sedes_delegaciones.ToList().Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.nombre
            });
            return View(model);
        }

        // POST: Voluntarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidos,direccionPostal,codigoPostal,localidad,provincia,pais,telefono1,telefono2,email,fechaNacimiento,fechaAlta,Sede,Perfiles")] voluntario voluntario)
        {
            if (ModelState.IsValid)
            {
                //Get id of sede_name
                var sedes = db.sedes_delegaciones.SingleOrDefault(i => i.nombre == voluntario.Sede);

                //Convert date
                var fecha = Convert.ToDateTime(voluntario.fechaNacimiento);

                //Profile id is 1 for Voluntarios
                //Transform voluntario class in voluntarios class to allow insert, updating, deleting
                //Insert a new volunteer through voluntarios table
                var voluntariosNuevo = new voluntarios(0, voluntario.nombre, voluntario.apellidos, voluntario.direccionPostal, voluntario.codigoPostal, voluntario.localidad, voluntario.provincia, voluntario.pais,
                    voluntario.telefono1, voluntario.telefono2, voluntario.email, fecha, voluntario.fechaAlta, sedes.id);
                db.voluntarios.Add(voluntariosNuevo);
                db.SaveChanges();

                //Insert the relationship many to many in personas_perfiles
                var perPerfilNew = new personas_perfiles(0, voluntariosNuevo.id, 1);
                db.persona_perfil.Add(perPerfilNew);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(voluntario);
        }

        // GET: Voluntarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voluntario voluntario = db.voluntario.SingleOrDefault(m => m.id == id);
            if (voluntario == null)
            {
                return HttpNotFound();
            }
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
                db.Entry(voluntario).State = EntityState.Modified;
                db.SaveChanges();
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
            voluntario voluntario = db.voluntario.SingleOrDefault(m => m.id == id);
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
            voluntario voluntario = db.voluntario.SingleOrDefault(m => m.id == id);
            db.voluntario.Remove(voluntario);
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
    }
}
