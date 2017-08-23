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
using System.Globalization;

namespace GestorONG.Controllers
{
    public class VistaColaboradoresController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        // GET: VistaColaboradores
        public ActionResult Index()
        {
            return View(db.vistaColaboradores.ToList());
        }

        // GET: VistaColaboradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vistaColaboradores datosColaborador = db.vistaColaboradores.SingleOrDefault(m => m.id == id);
            if (datosColaborador == null)
            {
                return HttpNotFound();
            }
            return View(datosColaborador);
        }

        // GET: VistaColaboradores/Create
        public ActionResult Create()
        {
            //Se cargan las periodicidades en el campo y se realiza un select box
            var listPeriodicidades = db.periodicidades.ToList().Select(x => new SelectListItem
            {
                Text = x.nombre,
                Value = x.id.ToString()
            });
            ViewBag.Periodicidades = listPeriodicidades;

            return View();
        }

        // POST: VistaColaboradores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidos,direccionPostal,codigoPostal,localidad,provincia,pais,telefono1,telefono2,email,fechaNacimiento,CIF_NIF,CuentaBancaria,Perfiles,cantidad,fechaAlta,Periodicidad")] vistaColaboradores modelo)
        {
            if (ModelState.IsValid)
            {
                //Se convierten los campos de tipo fecha
                var fechaNacimiento = Convert.ToDateTime(modelo.fechaNacimiento);
                var fechaAlta = Convert.ToDateTime(modelo.fechaAlta);

                //Se genera el colaborador
                var nuevoColaborador = new colaboradores(0,modelo.nombre,modelo.apellidos,modelo.direccionPostal,modelo.codigoPostal,modelo.localidad,modelo.provincia,modelo.pais,modelo.telefono1,modelo.telefono2,
                    modelo.email,fechaNacimiento,modelo.CIF_NIF,modelo.CuentaBancaria);
                db.colaboradores.Add(nuevoColaborador);
                db.SaveChanges();

                //Insert the relationship many to many in personas_perfiles
                var perPerfilNew = new personas_perfiles(0, nuevoColaborador.id, 2);
                db.persona_perfil.Add(perPerfilNew);
                db.SaveChanges();

                //Insert Donation
                int idPeriodicidad;
                int.TryParse(modelo.Periodicidad, out idPeriodicidad);
                var donacion = new donaciones(0, modelo.cantidad, fechaAlta, nuevoColaborador.id, idPeriodicidad);
                db.donaciones.Add(donacion);
                db.SaveChanges();

                //Se envía mensaje de acierto
                TempData["Acierto"] = "El colaborador/a " + modelo.nombre + " " + modelo.apellidos + " ha sido añadido/a correctamente al sistema.";

                return RedirectToAction("Index");
            }
            //Se cargan las periodicidades en el campo y se realiza un select box
            var listPeriodicidades = db.periodicidades.ToList().Select(x => new SelectListItem
            {
                Text = x.nombre,
                Value = x.id.ToString()
            });
            ViewBag.Periodicidades = listPeriodicidades;
            return View(modelo);
        }

        // GET: VistaColaboradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Se busca el colaborador con id
            vistaColaboradores colaborador = db.vistaColaboradores.SingleOrDefault(m => m.id == id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }

            return View(colaborador);
        }

        // POST: VistaColaboradores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellidos,direccionPostal,codigoPostal,localidad,provincia,pais,telefono1,telefono2,email,fechaNacimiento,CIF_NIF,CuentaBancaria,Perfiles")] vistaColaboradores modelo)
        {
            if (ModelState.IsValid)
            {
                //Se convierten los campos de tipo fecha
                var fechaNacimiento = Convert.ToDateTime(modelo.fechaNacimiento);

                //Transform vistaColaborador class in colaborador class to allow insert, updating, deleting
                var colaboradorActualizado = new colaboradores(modelo.id, modelo.nombre, modelo.apellidos, modelo.direccionPostal, modelo.codigoPostal, modelo.localidad, modelo.provincia, modelo.pais, modelo.telefono1, modelo.telefono2,
                    modelo.email, fechaNacimiento, modelo.CIF_NIF, modelo.CuentaBancaria);

                db.Entry(colaboradorActualizado).State = EntityState.Modified;
                db.SaveChanges();
                //It is no needed to update personas_perfiles because now, we do not allow to modify the profile
                TempData["Acierto"] = "El colaborador/a " + modelo.nombre + " " + modelo.apellidos + " ha sido editado correctamente.";
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: VistaColaboradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Se busca el colaborador con id
            vistaColaboradores colaborador = db.vistaColaboradores.SingleOrDefault(m => m.id == id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: VistaColaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Se eliminan los datos del colaborador
            colaboradores colaborador = db.colaboradores.SingleOrDefault(m => m.id == id);

            //Also needed to delete from personas_perfiles when is colaborator (2)
            personas_perfiles per = db.persona_perfil.Where(m => m.idPersona == id && m.idPerfil == 2).SingleOrDefault();
            db.persona_perfil.Remove(per);
            db.SaveChanges();

            // Delete donations made from this colaborator
            donaciones donacion = db.donaciones.SingleOrDefault(m => m.idColaborador == id);
            db.donaciones.Remove(donacion);
            db.SaveChanges();

            TempData["Acierto"] = "El colaborador/a " + colaborador.nombre + " " + colaborador.apellidos + " ha sido eliminada del sistema correctamente.";

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
