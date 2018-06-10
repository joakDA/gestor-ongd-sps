using System;
using System.ComponentModel;

namespace GestorONG.ViewModel
{
    /// <summary>
    /// Class used to display donation's information in a table using server side proccessing.
    /// </summary>
    public class DonationsViewModel
    {
        #region PUBLIC_MEMBER_PROPERTIES

        public int id { get; set; }
        /// <summary>
        /// Donation's amount.
        /// </summary>
        [DisplayName("Cantidad")]
        public Single amount { get; set; }
        /// <summary>
        /// donation's sign up date.
        /// </summary>
        [DisplayName("Fecha de Alta")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime donationDate { get; set; }

        /// <summary>
        /// Bank account of collaborator.
        /// </summary>
        [DisplayName("Cuenta Bancaria")]
        public string bankAccount { get; set; }

        /// <summary>
        /// Personal identification number of collaborator.
        /// </summary>
        [DisplayName("NIF / CIF")]
        public string NIF { get; set; }

        /// <summary>
        /// Name and last name of collaborator.
        /// </summary>
        public string collaborator { get; set; }

        /// <summary>
        /// Donation's periodicity.
        /// </summary>
        public string periodicity { get; set; }

        #endregion
    }
}