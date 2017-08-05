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

namespace GestorONG.Controllers
{
    public class SedesController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        // GET: Sedes
        public ActionResult Index()
        {
            return View(db.sedes_delegaciones.ToList());
        }

        // GET: Sedes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sede_delegacion sede_delegacion = db.sedes_delegaciones.Find(id);
            if (sede_delegacion == null)
            {
                return HttpNotFound();
            }
            return View(sede_delegacion);
        }

        // GET: Sedes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sedes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,direccion,codigoPostal,localidad,provincia,pais,personaContacto,emailContacto,telefonoContacto")] sede_delegacion sede_delegacion)
        {
            if (ModelState.IsValid)
            {
                db.sedes_delegaciones.Add(sede_delegacion);
                db.SaveChanges();
                TempData["Acierto"] = "La sede " + sede_delegacion.nombre + " ha sido añadida correctamente al sistema.";
                return RedirectToAction("Index");
            }

            return View(sede_delegacion);
        }

        // GET: Sedes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sede_delegacion sede_delegacion = db.sedes_delegaciones.Find(id);
            if (sede_delegacion == null)
            {
                return HttpNotFound();
            }
            return View(sede_delegacion);
        }

        // POST: Sedes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,direccion,codigoPostal,localidad,provincia,pais,personaContacto,emailContacto,telefonoContacto")] sede_delegacion sede_delegacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sede_delegacion).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Acierto"] = "La sede " + sede_delegacion.nombre + " ha sido editada correctamente.";
                return RedirectToAction("Index");
            }
            return View(sede_delegacion);
        }

        // GET: Sedes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sede_delegacion sede_delegacion = db.sedes_delegaciones.Find(id);
            if (sede_delegacion == null)
            {
                return HttpNotFound();
            }
            return View(sede_delegacion);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sede_delegacion sede_delegacion = db.sedes_delegaciones.Find(id);
            db.sedes_delegaciones.Remove(sede_delegacion);
            db.SaveChanges();
            TempData["Acierto"] = "La sede " + sede_delegacion.nombre + " ha sido eliminada del sistema correctamente.";
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
