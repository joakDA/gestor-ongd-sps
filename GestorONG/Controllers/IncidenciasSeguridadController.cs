using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GestorONG.DAL;
using GestorONG.DataModel;
using System.Collections.Generic;
using GestorONG.Models;
using Microsoft.AspNet.Identity;
using GestorONG.App_Start;
using GestorONG.ViewModel;
using System;
using Newtonsoft.Json;

namespace GestorONG.Controllers
{
    [Authorize]
    public class IncidenciasSeguridadController : Controller
    {
        #region PRIVATE_MEMBER_PROPERTIES

        /// <summary>  
        /// Database Store property.    
        /// </summary>  
        private ApplicationDbContext context = new ApplicationDbContext();

        private GestorONGDContext db = new GestorONGDContext();

        #endregion

        #region INDEX_METHODS

        // GET: IncidenciasSeguridads
        public ActionResult Index()
        {
            //return View(db.incidenciasSeguridads.Include(x => x.tiposIncidencias).Include(x => x.empleados).Include(x => x.empleados1).ToList());
            List<SecurityIncidentView> securityIncidents = ConvertIncidenciasSeguridadFromDBToView(db.incidenciasSeguridads.ToList());
            return View(securityIncidents);
        }

        /// <summary>
        /// Load data from server.
        /// </summary>
        /// <returns>List of collaborators to show in JQuery Datatable.</returns>
        [HttpPost]
        [Authorize]
        public ActionResult LoadData()
        {
            JsonResult jsonResult;
            string type = "";
            string comunicant = "";
            string receptor = "";

            string draw = "";
            int start = 0;
            int length = 0;
            int totalRecords = 0;
            int recordsFiltered = 0;
            //To save collaborator filtered.
            IQueryable<incidenciasSeguridad> securityIncidents;
            try
            {
                var search = Request["search[value]"];
                //jQuery DataTables Param
                draw = Request.Form.GetValues("draw").FirstOrDefault();
                //Find paging info
                start = Convert.ToInt32(Request.Form.GetValues("start").FirstOrDefault());
                length = Convert.ToInt32(Request.Form.GetValues("length").FirstOrDefault());

                //Filter
                type = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
                comunicant = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();
                receptor = Request.Form.GetValues("columns[7][search][value]").FirstOrDefault();

                //Sort
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][data]").FirstOrDefault();
                sortColumn = ConvertSortColumn(sortColumn);
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

                securityIncidents = new SecurityIncidentsRepository().GetPaginated(search, start, length, out totalRecords, out recordsFiltered, sortColumn,
                    sortColumnDir, type, comunicant, receptor);
            }
            catch (Exception)
            {
                securityIncidents = db.incidenciasSeguridads.AsQueryable();
                recordsFiltered = securityIncidents.Count();
                totalRecords = recordsFiltered;
            }

            List<SecurityIncidentView> viewData = ConvertIncidenciasSeguridadFromDBToView(securityIncidents.ToList());
            //Returning Json Data
            jsonResult = Json(new { draw = draw, recordsFiltered = recordsFiltered, recordsTotal = totalRecords, data = viewData });
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// Retrieve unique values for each filter field.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public string GetSelectData()
        {
            Dictionary<string, List<object>> jsonToSerialize = new Dictionary<string, List<object>>();

            //IncidentsTypes
            IQueryable<object> values = db.tiposIncidencias.Select(x => x.nombreIncidencia).Distinct();
            jsonToSerialize.Add("incidentsTypes", values.ToList());

            //Comunicant
            values = db.empleados.Select(x => x.nombre + " " + x.apellidos).Distinct();
            jsonToSerialize.Add("Comunicant", values.ToList());

            //Location
            jsonToSerialize.Add("Receptor", values.ToList());

            //Periodicity

            string jsonSerialized = JsonConvert.SerializeObject(jsonToSerialize, Formatting.Indented);

            return jsonSerialized;
        }

        /// <summary>
        /// Convert a list of "IncidenciasSeguridad" with data retrieved from database to a list of "SecurityIncidentView" to display data on view.
        /// </summary>
        /// <param name="incidenciasSeguridad">List of "IncidenciasSeguridad" with data retrieved from database.</param>
        /// <returns></returns>
        private List<SecurityIncidentView> ConvertIncidenciasSeguridadFromDBToView(List<incidenciasSeguridad> incidenciasSeguridad)
        {
            List<SecurityIncidentView> result = incidenciasSeguridad.Select(item => new SecurityIncidentView()
            {
                id = item.id,
                incidentDate = item.fechaIncidencia,
                incidentType = item.tiposIncidencias.nombreIncidencia,
                description = item.descripcion,
                derivedEffects = item.efectosDerivados,
                correctiveMeasures = item.medidasCorrectoras,
                comunicant = string.Format("{0} {1}",item.empleados.nombre,item.empleados.apellidos),
                receptor = string.Format("{0} {1}",item.empleados1.nombre, item.empleados1.apellidos)
            }).ToList();

            return result;
        }

        /// <summary>
        /// Convert sortColumn from SecurityIncidentView property name to incidenciasSeguridad property name to make sort work.
        /// </summary>
        /// <param name="sortColumn">sortColumn from SecurityIncidentView property name</param>
        /// <returns></returns>
        private string ConvertSortColumn(string sortColumn)
        {
            string sResult = "";

            switch (sortColumn)
            {
                case "incidentDate":
                    sResult = "fechaIncidencia";
                    break;
                case "incidentType":
                    sResult = "idTipoIncidencia";
                    break;
                case "description":
                    sResult = "descripcion";
                    break;
                case "derivedEffects":
                    sResult = "efectosDerivados";
                    break;
                case "correctiveMeasures":
                    sResult = "medidasCorrectoras";
                    break;
                case "comunicant":
                    sResult = "idComunicante";
                    break;
                case "receptor":
                    sResult = "idReceptor";
                    break;
                default:
                    sResult = "id";
                    break;
            }

            return sResult;
        }

        #endregion

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
            ViewBag.TiposIncidencia = GetSelectListFromListTiposIncidencias(db.tiposIncidencias.ToList(), 0);
            ViewBag.Usuarios = GetSelectListFromListEmpleados(db.empleados.ToList(), 0);
            return View();
        }

        // POST: IncidenciasSeguridads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fechaIncidencia,idTipoIncidencia,descripcion,efectosDerivados,medidasCorrectoras,idComunicante,idReceptor")] incidenciasSeguridad incidenciasSeguridad)
        {
            ViewBag.TiposIncidencia = GetSelectListFromListTiposIncidencias(db.tiposIncidencias.ToList(), 0);
            ViewBag.Usuarios = GetSelectListFromListEmpleados(db.empleados.ToList(), 0);
            if (ModelState.IsValid)
            {
                db.incidenciasSeguridads.Add(incidenciasSeguridad);
                db.SaveChanges();
                TempData["Acierto"] = string.Format("Se ha registrado correctamente la incidencia de seguridad con identificador {0} en el sistema del tipo \"{1}\" con fecha {2}", incidenciasSeguridad.id,
                    incidenciasSeguridad.tiposIncidencias.nombreIncidencia, incidenciasSeguridad.fechaIncidencia.ToString("dd/MM/yyyy"));
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Ha habido un error al registrar la incidencia de seguridad. Por favor, inténtalo de nuevo";
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

            ViewBag.TiposIncidencia = GetSelectListFromListTiposIncidencias(db.tiposIncidencias.ToList(), 0);
            ViewBag.Usuarios = GetSelectListFromListEmpleados(db.empleados.ToList(), 0);

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
            ViewBag.TiposIncidencia = GetSelectListFromListTiposIncidencias(db.tiposIncidencias.ToList(), 0);
            ViewBag.Usuarios = GetSelectListFromListEmpleados(db.empleados.ToList(), 0);

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

        /// <summary>
        /// Convert a List
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetSelectListFromListTiposIncidencias(List<tiposIncidencias> lista, int currentValue)
        {
            IEnumerable<SelectListItem> result;
            result = lista.Select(x => new SelectListItem()
            {
                Text = x.nombreIncidencia,
                Value = x.id.ToString(),
                Selected = x.id == currentValue
            });

            return result;
        }

        /// <summary>
        /// Convert a List
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetSelectListFromListEmpleados(List<empleados> lista, int currentValue)
        {
            IEnumerable<SelectListItem> result;
            result = lista.Select(x => new SelectListItem()
            {
                Text = x.nombre + " " + x.apellidos,
                Value = x.id.ToString(),
                Selected = x.id == currentValue
            });

            return result;
        }
    }
}
