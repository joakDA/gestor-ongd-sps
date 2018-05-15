using GestorONG.DAL;
using GestorONG.DataModel;
using System;
using System.Linq;
using System.Linq.Dynamic;

namespace GestorONG.Models
{
    public class SecurityIncidentsRepository : IPaginationSecurityIncidents<incidenciasSeguridad>
    {
        #region PRIVATE_MEMBER_PROPERTIES
        /// <summary>
        /// Used to make CRUD operations in database using EF.
        /// </summary>
        private GestorONGDContext context = new GestorONGDContext();

        #endregion

        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Get data paginated.
        /// </summary>
        /// <param name="filter">Filter applied by user.</param>
        /// <param name="initialPage">Initial page.</param>
        /// <param name="pageSize">Amount of records for each page.</param>
        /// <param name="totalRecords">Total of records.</param>
        /// <param name="recordsFiltered">Total records filtered when filter applied.</param>
        /// <param name="sortColumn">Column used to sort.</param>
        /// <param name="sortColumnDir">Direction to sort results (ascending, descending).</param>
        /// <returns>List of all elements found that matches criteria.</returns>
        public IQueryable<incidenciasSeguridad> GetPaginated(string filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered, string sortColumn,
            string sortColumnDir, string type, string comunicant, string receptor)
        {
            IQueryable<incidenciasSeguridad> data;

            data = context.incidenciasSeguridads.AsQueryable();

            //Total result in database.
            totalRecords = data.Count();

            //Apply filters

            if (type != "N/A" && !string.IsNullOrEmpty(type))
            {
                data = data.Where(x => x.tiposIncidencias.nombreIncidencia.ToUpper() == type.ToUpper());
            }

            if (comunicant != "N/A" && !string.IsNullOrEmpty(comunicant))
            {
                string[] sComunicant = comunicant.Split(' ');
                string sName = sComunicant[0];
                string sLastName = sComunicant[1];
                data = data.Where(x => x.empleados.nombre.ToUpper() == sName.ToUpper() && x.empleados.apellidos.ToUpper() == sLastName.ToUpper());
            }

            if (receptor != "N/A" && !string.IsNullOrEmpty(receptor))
            {
                string[] sReceptor = receptor.Split(' ');
                string sName = sReceptor[0];
                string sLastName = sReceptor[1];
                data = data.Where(x => x.empleados1.nombre.ToUpper() == sName.ToUpper() && x.empleados1.apellidos.ToUpper() == sLastName.ToUpper());
            }

            recordsFiltered = data.Count();

            //Sorting
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                try
                {
                    data = data.OrderBy(sortColumn + " " + sortColumnDir);
                }
                catch (Exception)
                {
                }
            }

            if (pageSize != -1)
            {
                data = data.Skip((initialPage))
                    .Take(pageSize);
            }

            return data;
        }

        #endregion
    }
}