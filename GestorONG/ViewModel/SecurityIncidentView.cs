using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestorONG.ViewModel
{
    /// <summary>
    /// Class used to display security incident information in view.
    /// </summary>
    public class SecurityIncidentView
    {
        #region PUBLIC_MEMBER_PROPERTIES

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Fecha y hora de la incidencia")]
        public System.DateTime incidentDate { get; set; }

        [Display(Name = "Tipo de incidencia de seguridad")]
        public string incidentType { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(300, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string description { get; set; }

        [Display(Name = "Efectos derivados")]
        [StringLength(300, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string derivedEffects { get; set; }

        [Display(Name = "Medidas correctoras")]
        [StringLength(300, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string correctiveMeasures { get; set; }

        [Display(Name = "Comunicante de la incidencia")]
        public string comunicant { get; set; }

        [Display(Name = "Receptor de la incidencia")]
        public string receptor { get; set; }

        #endregion
    }
}