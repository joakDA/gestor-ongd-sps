using GestorONG.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestorONG.ViewModel
{
    /// <summary>
    /// Clase para almacenar los datos de las donaciones y los colaboradores a la hora de crear,editar o ver los detalles de una donación.
    /// </summary>
    public class DonacionesViewModel
    {
        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public DonacionesViewModel()
        {

        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="donacion">Objeto de la clase donaciones para guardar los datos de la donación.</param>
        /// <param name="cuentaBancaria">String para almacenar el número de cuenta bancaria de la donación.</param>
        /// <param name="NIF">String para almacenar el NIF/CIF del colaborador.</param>
        public DonacionesViewModel(donaciones donacion, string cuentaBancaria, string NIF)
        {
            this.donacion = donacion;
            this.cuentaBancaria = cuentaBancaria;
            this.NIF = NIF;
        }

        #endregion

        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// Objeto de la clase donaciones para guardar los datos de la donación.
        /// </summary>
        public donaciones donacion { get; set; }

        /// <summary>
        /// String para almacenar el número de cuenta bancaria de la donación.
        /// </summary>
        [DisplayName("Cuenta Bancaria")]
        [Required]
        [StringLength(24)]
        public string cuentaBancaria { get; set; }

        /// <summary>
        /// String para almacenar el NIF/CIF del colaborador.
        /// </summary>
        [DisplayName("NIF / CIF")]
        [Required]
        [StringLength(9)]
        public string NIF { get; set; }

        #endregion
    }
}