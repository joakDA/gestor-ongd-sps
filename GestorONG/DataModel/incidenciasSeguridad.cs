//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class incidenciasSeguridad
    {
        #region PUBLIC_MEMBER_PROPERTIES

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Fecha y hora en la que se produjo la incidencia de seguridad.
        /// </summary>
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Fecha y hora de la incidencia")]
        public System.DateTime fechaIncidencia { get; set; }

        [Display(Name = "Tipo de incidencia de seguridad")]
        public int idTipoIncidencia { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(300, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string descripcion { get; set; }

        [Display(Name = "Efectos derivados")]
        [StringLength(300, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string efectosDerivados { get; set; }

        [Display(Name = "Medidas correctoras")]
        [StringLength(300, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string medidasCorrectoras { get; set; }

        [Display(Name = "Comunicante de la incidencia")]
        public int idComunicante { get; set; }

        [Display(Name = "Receptor de la incidencia")]
        public int idReceptor { get; set; }
    
        public virtual empleados empleados { get; set; }
        public virtual empleados empleados1 { get; set; }
        public virtual tiposIncidencias tiposIncidencias { get; set; }

        #endregion
    }
}
