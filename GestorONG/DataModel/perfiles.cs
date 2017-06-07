namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Almacena los datos sobre los perfiles de la aplicacion (Voluntario, Colaborador, ...)
    /// </summary>
    public partial class perfiles
    {
        #region PUBLIC_MEMBER_METHODS

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public perfiles()
        {
            this.personas_perfiles = new HashSet<personas_perfiles>();
        }

        /// <summary>
        /// Constructor por parámetros
        /// </summary>
        /// <param name="id">ID Autoincremental de la base de datos del perfil</param>
        /// <param name="nombre">Nombre del perfil (Por ejemplo: Voluntario, Colaborador, ...)</param>
        public perfiles(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        #endregion

        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// ID Autoincremental de la base de datos del perfil
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nombre del perfil (Por ejemplo: Voluntario, Colaborador, ...)
        /// </summary>
        public string nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personas_perfiles> personas_perfiles { get; set; }

        #endregion
    }
}
