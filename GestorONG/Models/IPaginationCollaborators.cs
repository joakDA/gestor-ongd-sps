using System;
using System.Linq;

namespace GestorONG.Models
{
    interface IPaginationCollaborators<T> where T:class
    {
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
        IQueryable<T> GetPaginated(string filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered, string sortColumn,
            string sortColumnDir, string country, string CIF_NIF, Single quantity, string periodicity);
    }
}
