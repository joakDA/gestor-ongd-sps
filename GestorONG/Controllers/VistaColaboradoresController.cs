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
    public class VistaColaboradoresController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        // GET: VistaColaboradores
        public ActionResult Index()
        {
            //Se pasa el listado de paises en el ViewBag para poder introducir un listado de filtros.
            var paises = new SelectList(db.vistaColaboradores.Select(p => p.pais).Distinct().ToList());
            ViewBag.Paises = paises;

            return View(db.vistaColaboradores.ToList());
        }

        [HttpPost]
        /*public ActionResult Index(string Paises)
        {
            //Se pasa el listado de paises en el ViewBag para poder introducir un listado de filtros.
            var paises = new SelectList(db.vistaColaboradores.Select(p => p.pais).Distinct().ToList());
            ViewBag.Paises = paises;
            //Now check model.FirstName 
            return View(db.vistaColaboradores.Where(p => p.pais == Paises).ToList());
        }*/

        // GET: VistaColaboradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vistaColaboradores vistaColaboradores = db.vistaColaboradores.Find(id);
            if (vistaColaboradores == null)
            {
                return HttpNotFound();
            }
            return View(vistaColaboradores);
        }

        // GET: VistaColaboradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VistaColaboradores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidos,direccionPostal,codigoPostal,localidad,provincia,pais,telefono1,telefono2,email,fechaNacimiento,CIF_NIF,CuentaBancaria,Perfiles,cantidad,fechaAlta,Periodicidad")] vistaColaboradores vistaColaboradores)
        {
            if (ModelState.IsValid)
            {
                db.vistaColaboradores.Add(vistaColaboradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vistaColaboradores);
        }

        // GET: VistaColaboradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vistaColaboradores vistaColaboradores = db.vistaColaboradores.Find(id);
            if (vistaColaboradores == null)
            {
                return HttpNotFound();
            }
            return View(vistaColaboradores);
        }

        // POST: VistaColaboradores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellidos,direccionPostal,codigoPostal,localidad,provincia,pais,telefono1,telefono2,email,fechaNacimiento,CIF_NIF,CuentaBancaria,Perfiles,cantidad,fechaAlta,Periodicidad")] vistaColaboradores vistaColaboradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vistaColaboradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vistaColaboradores);
        }

        // GET: VistaColaboradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vistaColaboradores vistaColaboradores = db.vistaColaboradores.Find(id);
            if (vistaColaboradores == null)
            {
                return HttpNotFound();
            }
            return View(vistaColaboradores);
        }

        // POST: VistaColaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vistaColaboradores vistaColaboradores = db.vistaColaboradores.Find(id);
            db.vistaColaboradores.Remove(vistaColaboradores);
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
