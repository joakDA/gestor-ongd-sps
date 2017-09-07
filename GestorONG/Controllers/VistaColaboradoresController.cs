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
using GestorONG.ViewModel;
using System.IO;

namespace GestorONG.Controllers
{
    public class VistaColaboradoresController : Controller
    {
        private GestorONGDContext db = new GestorONGDContext();

        private DonacionesController donacionesContr = new DonacionesController();

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

        /// <summary>
        /// Genera un certificado en formato PDF de cada uno de los colaboradores con donaciones en el año anterior
        /// </summary>
        /// <returns></returns>
        public ActionResult Certificados()
        {
            //Se declara el objeto para guardar los datos y pasárselos al writer en PDF
            var certificadosData = new GenerarCertificadosViewModel()
            {
                listadoColaboradores = new List<CertificadoViewModel>()
            };

            var fechaActual = DateTime.Now;
            // Se detecta el año actual y se calcula el anterior
            var añoCertificados = fechaActual.Date.AddYears(-1);

            // Se recorre la lista de colaboradores, obteniendo sus donaciones y calculando el importe total
            var colaboradoresList = db.colaboradores.Include(x => x.donaciones).ToList();

            foreach(colaboradores col in colaboradoresList)
            {
                // Se guarda la donación en un objeto
                var donacion = col.donaciones.FirstOrDefault();
                try
                {
                    var fechaAlta = donacion.fechaAlta;
                    // Calcular el número de meses desde que es colaborador
                    Double numMeses = ((fechaActual.Year - fechaAlta.Year) * 12) + fechaActual.Month - fechaAlta.Month;

                    // Si el numMeses es mayor que 12, lo truncamos a 12
                    if (numMeses > 12)
                    {
                        numMeses = 12;
                    }

                    Double cantidadTotalDonada = 0.0;
                    // Con el switch miramos la periodicidad y calculamos un valor para multiplicar por la cantidad y obtener la cantidad total
                    switch (donacion.idPeriodicidad)
                    {
                        //Mensual: 12 x la cantidad
                        case 1:
                            cantidadTotalDonada = numMeses * donacion.cantidad;
                            break;
                        //Bimensual: numMeses / 2 * cantidad
                        case 2:
                            numMeses = numMeses / 2;
                            cantidadTotalDonada = (Math.Truncate(numMeses / 2)) * donacion.cantidad;
                            break;
                        //Trimestral: numMeses / 3 * cantidad
                        case 3:
                            cantidadTotalDonada = (Math.Truncate(numMeses / 3)) * donacion.cantidad;
                            break;
                        //Semestral: numMeses / 6 * cantidad
                        case 4:
                            cantidadTotalDonada = (Math.Truncate(numMeses / 6)) * donacion.cantidad;
                            break;
                        //Anual: numMeses / 12 * cantidad
                        case 5:
                            cantidadTotalDonada = (Math.Truncate(numMeses / 12)) * donacion.cantidad;
                            break;
                        default:
                            cantidadTotalDonada = 0.0;
                            break;
                    }
                    // Genero el objeto para el certificado
                    var certificadoModel = new CertificadoViewModel()
                    {
                        nombreApellidos = col.apellidos + ", " + col.nombre,
                        CIF_NIF = col.CIF_NIF,
                        cantidadTotal = Math.Round(cantidadTotalDonada, 2)
                    };

                    // Se añade el objeto generado a la lista
                    certificadosData.listadoColaboradores.Add(certificadoModel);
                }catch(Exception e)
                {
                    Console.Write("Colaborador con donación nula: " + e.Message);
                    continue;
                }
            }
            GenerarCertificadosRenta(certificadosData);

            return RedirectToAction("Index");
        }

        private void GenerarCertificadosRenta(GenerarCertificadosViewModel listadoCert)
        {
            var year = DateTime.Now.AddYears(-1);
            foreach (CertificadoViewModel cert in listadoCert.listadoColaboradores)
            {
                string nombreApellidos = cert.nombreApellidos.Replace(' ', '_');
                nombreApellidos = nombreApellidos.Replace(',', '_');
                string fileName = "Certificado_" + nombreApellidos + ".pdf";
                // Se establecen los parámetros del PDF
                var actionPDF = new Rotativa.ActionAsPdf("generateCertificadoPDF", cert)
                {
                    FileName = fileName,
                    PageSize = Rotativa.Options.Size.A4,
                    PageOrientation = Rotativa.Options.Orientation.Portrait,
                    PageMargins = { Left = 1, Top = 1, Right = 1, Bottom = 1 }
                };
                // Se escribe en un array de bytes
                byte[] applicationPDFData = actionPDF.BuildPdf(ControllerContext);
                // Se guarda en disco
                /*string path = "~/App_Data/Certificados/" + year + "/" +  fileName;
                string path2 = Server.MapPath(path);*/
                string path2 = "~/App_Data/Certiificados/";
                savePDFOnDisk(applicationPDFData, path2, fileName);
            }
        }

        public ActionResult generateCertificadoPDF (CertificadoViewModel data)
        {
            return View(data);
        }

        /// <summary>
        /// Guarda un array de bytes en una carpeta
        /// </summary>
        /// <param name="applicationPDFData">Array de bits para generar el archivo.</param>
        private void savePDFOnDisk(byte[] applicationPDFData, string ruta, string nombre)
        {
            string aux = Path.Combine(ruta, nombre);
            string ruta2 = Server.MapPath(aux);
            var dir = new DirectoryInfo(ruta);
            // Chequea si la carpeta existe
            /*if (!dir.Exists)
            {
                dir.Create();
            }else
            {
                
            }*/

            FileStream fileStream = new FileStream(ruta2, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(applicationPDFData, 0, applicationPDFData.Length);
            fileStream.Close();
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
