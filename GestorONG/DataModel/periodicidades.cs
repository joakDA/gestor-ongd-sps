namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase que almacena los datos de las diferentes periodicidades (mensual, trimestral, anual).
    /// </summary>
    public partial class periodicidades
    {
        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public periodicidades()
        {
            this.donaciones = new HashSet<donaciones>();
        }

        /// <summary>
        /// Constructor por parámetros de periodicidades
        /// </summary>
        /// <param name="id">ID Autoincremental del registro.</param>
        /// <param name="nombre">Nombre de la periodicidad. Por ejemplo: mensual.</param>
        public periodicidades(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        #endregion

        #region PUBLIC_MEMBER_VARIABLES
        /// <summary>
        /// Id autoncremental del colaborador. Lo genera la BBDD.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nombre de la periodicidad. Por ejemplo: mensual.
        /// </summary>
        [DisplayName("Nombre")]
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donaciones> donaciones { get; set; }

        #endregion
    }
}
