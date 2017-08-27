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
                var persona = db.persona.Find(modelo.donacion.idColaborador);

                db.Entry(persona).State = EntityState.Detached;
                var colaborador = new colaboradores(new personas(persona),modelo.NIF,modelo.cuentaBancaria);
                /*db.persona.Attach(persona);
                db.Entry(colaborador).State = EntityState.Added;
                db.Entry(persona).State = EntityState.Modified;*/
                //colaborador.idColaborador = modelo.donacion.idColaborador;
                //db.colaboradores.Add(colaborador);
                persona.colaboradores.Add(colaborador);
                db.Entry(persona).State = EntityState.Modified;
                
                //db.Entry(colaborador).State = EntityState.Modified;
                //persona.colaboradores.Add(colaborador);
                //db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();

                //db.colaboradores.Add(colaborador);
                
                //db.Entry(persona).State = EntityState.Unchanged;
                

                //db.SaveChanges();
                // Añadir la relación entre personas y perfiles en la tabla personas_perfiles
                var personas_perfiles = new personas_perfiles(0, modelo.donacion.idColaborador, 2);
                db.persona_perfil.Add(personas_perfiles);
                db.SaveChanges();
                TempData["Acierto"] = "La donación creada por el colaborador " + persona.nombre + " " + persona.apellidos + " con un valor de " + modelo.donacion.cantidad + "€ ha sido realizada correctamente";
                return RedirectToAction("Index");
            }else
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                Console.Write(errors.ToString());
            }

            // Se listan las personas que no son colaboradores existentes en el sistema puesto que sólo se puede hacer una única donación por usuario.
            var perfil = db.perfil.SingleOrDefault(m => m.nombre == "Colaborador");
            var posiblesColaboradores = db.persona.Where(u => !u.personas_perfiles.Any(r => r.idPerfil == perfil.id));

            var colaboradores = posiblesColaboradores.Select(x => new SelectListItem
            {
                Text = x.nombre + " " + x.apellidos,
                Value = x.id.ToString()
            });

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
