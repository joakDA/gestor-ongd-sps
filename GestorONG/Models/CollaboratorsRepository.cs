/*MIT License

Copyright (c) 2017 joakDA

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/

using GestorONG.DAL;
using GestorONG.DataModel;
using System;
using System.Linq;
using System.Linq.Dynamic;

namespace GestorONG.Models
{
    public class CollaboratorsRepository : IPaginationCollaborators<vistaColaboradores>
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
        public IQueryable<vistaColaboradores> GetPaginated(string filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered,
            string sortColumn, string sortColumnDir, string country, string CIF_NIF, Single quantity, string periodicity)
        {
            IQueryable<vistaColaboradores> data;

            data = context.vistaColaboradores.AsQueryable();

            //Total result in database.
            totalRecords = data.Count();

            //TO DO: Apply filters
            if (country != "N/A" && !string.IsNullOrEmpty(country))
            {
                data = data.Where(x => x.pais.ToUpper() == country.ToUpper());
            }

            if (CIF_NIF != "N/A" && !string.IsNullOrEmpty(CIF_NIF))
            {
                data = data.Where(x => x.CIF_NIF.ToUpper() == CIF_NIF.ToUpper());
            }

            if (periodicity != "N/A" && !string.IsNullOrEmpty(periodicity))
            {
                data = data.Where(x => x.Periodicidad.ToUpper() == periodicity.ToUpper());
            }

            

            if (quantity > 0)
            {
                data = data.Where(x => x.cantidad == quantity);
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