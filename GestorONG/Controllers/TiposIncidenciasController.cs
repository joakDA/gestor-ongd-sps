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
    public class TiposIncidenciasController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        // GET: TiposIncidencias
        public ActionResult Index()
        {
            return View(db.tiposIncidencias.ToList());
        }

        // GET: TiposIncidencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposIncidencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombreIncidencia")] tiposIncidencias tiposIncidencias)
        {
            if (ModelState.IsValid)
            {
                db.tiposIncidencias.Add(tiposIncidencias);
                db.SaveChanges();
                TempData["Acierto"] = "El tipo de incidencia de seguridad " + tiposIncidencias.nombreIncidencia + " ha sido creado correctamente.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Error al crear el tipo de incidencia de seguridad. Por favor, inténtalo de nuevo.";
            return View(tiposIncidencias);
        }

        // GET: TiposIncidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tiposIncidencias tiposIncidencias = db.tiposIncidencias.Find(id);
            if (tiposIncidencias == null)
            {
                return HttpNotFound();
            }
            return View(tiposIncidencias);
        }

        // POST: TiposIncidencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombreIncidencia")] tiposIncidencias tiposIncidencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposIncidencias).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Acierto"] = "El tipo de incidencia de seguridad " + tiposIncidencias.nombreIncidencia + " ha sido editado correctamente.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Error al editar el tipo de incidencia de seguridad. Por favor, inténtalo de nuevo.";
            return View(tiposIncidencias);
        }

        // GET: TiposIncidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tiposIncidencias tiposIncidencias = db.tiposIncidencias.Find(id);
            if (tiposIncidencias == null)
            {
                return HttpNotFound();
            }
            return View(tiposIncidencias);
        }

        // POST: TiposIncidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tiposIncidencias tiposIncidencias = db.tiposIncidencias.Find(id);
            db.tiposIncidencias.Remove(tiposIncidencias);
            db.SaveChanges();
            TempData["Acierto"] = "El tipo de incidencia de seguridad " + tiposIncidencias.nombreIncidencia + " ha sido eliminado correctamente.";
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
