namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase para almacenar los tipos de incidencias de seguridad que puede haber en la organización.
    /// </summary>
    public partial class tiposIncidencias
    {
        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tiposIncidencias()
        {
            this.incidenciasSeguridad = new HashSet<incidenciasSeguridad>();
        }

        #endregion

        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// ID autoincremental de la tabla en la base de datos.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Nombre del tipo de incidencia de seguridad.
        /// </summary>
        [DisplayName("Nombre de la Incidencia")]
        [Required]
        [StringLength(250, ErrorMessage = "El nombre no puede tener más de 250 caracteres.")]
        public string nombreIncidencia { get; set; }
    
        /// <summary>
        /// Referencia a la tabla incidenciasSeguridad (Foreign Key)
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<incidenciasSeguridad> incidenciasSeguridad { get; set; }

        #endregion
    }
}
