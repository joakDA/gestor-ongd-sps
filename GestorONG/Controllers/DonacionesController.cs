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
            donaciones donaciones = db.donaciones.Find(id);
            if (donaciones == null)
            {
                return HttpNotFound();
            }
            return View(donaciones);
        }

        // GET: Donaciones/Create
        public ActionResult Create()
        {
            ViewBag.idColaborador = new SelectList(db.persona, "id", "nombre");
            ViewBag.idPeriodicidad = new SelectList(db.periodicidades, "id", "nombre");
            return View();
        }

        // POST: Donaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cantidad,fechaAlta,idColaborador,idPeriodicidad")] donaciones donaciones)
        {
            if (ModelState.IsValid)
            {
                db.donaciones.Add(donaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idColaborador = new SelectList(db.persona, "id", "nombre", donaciones.idColaborador);
            ViewBag.idPeriodicidad = new SelectList(db.periodicidades, "id", "nombre", donaciones.idPeriodicidad);
            return View(donaciones);
        }

        // GET: Donaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donaciones donaciones = db.donaciones.Find(id);
            if (donaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idColaborador = new SelectList(db.persona, "id", "nombre", donaciones.idColaborador);
            ViewBag.idPeriodicidad = new SelectList(db.periodicidades, "id", "nombre", donaciones.idPeriodicidad);
            return View(donaciones);
        }

        // POST: Donaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cantidad,fechaAlta,idColaborador,idPeriodicidad")] donaciones donaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idColaborador = new SelectList(db.persona, "id", "nombre", donaciones.idColaborador);
            ViewBag.idPeriodicidad = new SelectList(db.periodicidades, "id", "nombre", donaciones.idPeriodicidad);
            return View(donaciones);
        }

        // GET: Donaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donaciones donaciones = db.donaciones.Find(id);
            if (donaciones == null)
            {
                return HttpNotFound();
            }
            return View(donaciones);
        }

        // POST: Donaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            donaciones donaciones = db.donaciones.Find(id);
            db.donaciones.Remove(donaciones);
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
