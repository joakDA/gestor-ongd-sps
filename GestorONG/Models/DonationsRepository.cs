using GestorONG.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;
using GestorONG.DAL;

namespace GestorONG.Models
{
    public class DonationsRepository : IPaginationDonations<donaciones>
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
        public IQueryable<donaciones> GetPaginated(string filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered, string sortColumn,
            string sortColumnDir, Single amount, string nif, string collaborator, string periodicity)
        {
            IQueryable<donaciones> data;

            data = context.donaciones.AsQueryable();

            //Total result in database.
            totalRecords = data.Count();

            //Apply filters

            if (amount != 0)
            {
                data = data.Where(x => x.cantidad == amount);
            }

            if (nif != "N/A" && !string.IsNullOrEmpty(nif))
            {
                data = data.Where(x => x.colaboradores.CIF_NIF.ToUpper() == nif.ToUpper());
            }

            if (collaborator != "N/A" && !string.IsNullOrEmpty(collaborator))
            {
                string[] sCollaborator = collaborator.Split(' ');
                string sName = sCollaborator[0];
                string sLastName = sCollaborator[1];
                data = data.Where(x => x.colaboradores.nombre.ToUpper() == sName.ToUpper() && x.colaboradores.apellidos.ToUpper() == sLastName.ToUpper());
            }

            if (periodicity != "N/A" && !string.IsNullOrEmpty(periodicity))
            {
                data = data.Where(x => x.periodicidades.nombre.ToUpper() == periodicity.ToUpper());
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