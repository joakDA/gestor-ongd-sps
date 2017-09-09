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
    public class PeriodicidadesController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        // GET: Periodicidades
        public ActionResult Index()
        {
            return View(db.periodicidades.ToList());
        }

        // GET: Periodicidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Periodicidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] periodicidades periodicidades)
        {
            if (ModelState.IsValid)
            {
                db.periodicidades.Add(periodicidades);
                db.SaveChanges();
                TempData["Acierto"] = "La periodicidad " + periodicidades.nombre + " ha sido creada correctamente.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Error al crear la periodicidad. Por favor, inténtalo de nuevo.";
            return View(periodicidades);
        }

        // GET: Periodicidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            periodicidades periodicidades = db.periodicidades.Find(id);
            if (periodicidades == null)
            {
                return HttpNotFound();
            }
            return View(periodicidades);
        }

        // POST: Periodicidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] periodicidades periodicidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodicidades).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Acierto"] = "La periodicidad " + periodicidades.nombre + " ha sido editada correctamente.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Error al editar la periodicidad. Por favor, inténtalo de nuevo.";
            return View(periodicidades);
        }

        // GET: Periodicidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            periodicidades periodicidades = db.periodicidades.Find(id);
            if (periodicidades == null)
            {
                return HttpNotFound();
            }
            return View(periodicidades);
        }

        // POST: Periodicidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            periodicidades periodicidades = db.periodicidades.Find(id);
            db.periodicidades.Remove(periodicidades);
            db.SaveChanges();
            TempData["Acierto"] = "La periodicidad " + periodicidades.nombre + " ha sido eliminada correctamente.";
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
