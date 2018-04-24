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
    public class ControlDatosLOPDController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        // GET: ControlDatosLOPD
        public ActionResult Index()
        {
            return View(db.entradasSalidasInformacions.ToList());
        }

        // GET: ControlDatosLOPD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entradasSalidasInformacion entradasSalidasInformacion = db.entradasSalidasInformacions.Find(id);
            if (entradasSalidasInformacion == null)
            {
                return HttpNotFound();
            }
            return View(entradasSalidasInformacion);
        }

        // GET: ControlDatosLOPD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControlDatosLOPD/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipoDocumento,fecha,emisor,numDocumentos,tipoDatos,formaEnvio,personaResponsable")] entradasSalidasInformacion entradasSalidasInformacion)
        {
            if (ModelState.IsValid)
            {
                db.entradasSalidasInformacions.Add(entradasSalidasInformacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entradasSalidasInformacion);
        }

        // GET: ControlDatosLOPD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entradasSalidasInformacion entradasSalidasInformacion = db.entradasSalidasInformacions.Find(id);
            if (entradasSalidasInformacion == null)
            {
                return HttpNotFound();
            }
            return View(entradasSalidasInformacion);
        }

        // POST: ControlDatosLOPD/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipoDocumento,fecha,emisor,numDocumentos,tipoDatos,formaEnvio,personaResponsable")] entradasSalidasInformacion entradasSalidasInformacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradasSalidasInformacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entradasSalidasInformacion);
        }

        // GET: ControlDatosLOPD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            entradasSalidasInformacion entradasSalidasInformacion = db.entradasSalidasInformacions.Find(id);
            if (entradasSalidasInformacion == null)
            {
                return HttpNotFound();
            }
            return View(entradasSalidasInformacion);
        }

        // POST: ControlDatosLOPD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            entradasSalidasInformacion entradasSalidasInformacion = db.entradasSalidasInformacions.Find(id);
            db.entradasSalidasInformacions.Remove(entradasSalidasInformacion);
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
