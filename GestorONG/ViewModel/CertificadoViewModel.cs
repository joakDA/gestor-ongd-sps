using GestorONG.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestorONG.ViewModel
{
    /// <summary>
    /// Clase con la información de los certificados de cada colaborador.
    /// </summary>
    public class CertificadoViewModel
    {
        #region PUBLIC_MEMBER_VARIABLES

        [Key]
        public int id { get; set; }

        /// <summary>
        /// Colaborador al que emitir el certificado.
        /// </summary>
        public string nombreApellidos { get; set; }

        /// <summary>
        /// CIF_NIF del colaborador.
        /// </summary>
        public string CIF_NIF { get; set; }

        /// <summary>
        /// Cantidad total donada.
        /// </summary>
        public Double cantidadTotal { get; set; }

        #endregion
    }

    /// <summary>
    /// Clase para almacenar todos los colaboradores de los que generar los certificados
    /// </summary>
    public class GenerarCertificadosViewModel
    {
        #region PUBLIC_MEMBER_VARIABLES
        /// <summary>
        /// Listado con todos los colaboradores a los que emitir el certificado.
        /// </summary>
        public List<CertificadoViewModel> listadoColaboradores { get; set; }

        #endregion
    }

}