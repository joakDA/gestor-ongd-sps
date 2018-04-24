using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GestorONG.DAL;
using GestorONG.DataModel;

namespace GestorONG.Controllers
{
    [Authorize]
    public class IncidenciasSeguridadController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        // GET: IncidenciasSeguridads
        public ActionResult Index()
        {
            return View(db.incidenciasSeguridads.ToList());
        }

        // GET: IncidenciasSeguridads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incidenciasSeguridad incidenciasSeguridad = db.incidenciasSeguridads.Find(id);
            if (incidenciasSeguridad == null)
            {
                return HttpNotFound();
            }
            return View(incidenciasSeguridad);
        }

        // GET: IncidenciasSeguridads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncidenciasSeguridads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fechaIncidencia,idTipoIncidencia,descripcion,efectosDerivados,medidasCorrectoras,idComunicante,idReceptor")] incidenciasSeguridad incidenciasSeguridad)
        {
            if (ModelState.IsValid)
            {
                db.incidenciasSeguridads.Add(incidenciasSeguridad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incidenciasSeguridad);
        }

        // GET: IncidenciasSeguridads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incidenciasSeguridad incidenciasSeguridad = db.incidenciasSeguridads.Find(id);
            if (incidenciasSeguridad == null)
            {
                return HttpNotFound();
            }
            return View(incidenciasSeguridad);
        }

        // POST: IncidenciasSeguridads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fechaIncidencia,idTipoIncidencia,descripcion,efectosDerivados,medidasCorrectoras,idComunicante,idReceptor")] incidenciasSeguridad incidenciasSeguridad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incidenciasSeguridad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incidenciasSeguridad);
        }

        // GET: IncidenciasSeguridads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            incidenciasSeguridad incidenciasSeguridad = db.incidenciasSeguridads.Find(id);
            if (incidenciasSeguridad == null)
            {
                return HttpNotFound();
            }
            return View(incidenciasSeguridad);
        }

        // POST: IncidenciasSeguridads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            incidenciasSeguridad incidenciasSeguridad = db.incidenciasSeguridads.Find(id);
            db.incidenciasSeguridads.Remove(incidenciasSeguridad);
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
