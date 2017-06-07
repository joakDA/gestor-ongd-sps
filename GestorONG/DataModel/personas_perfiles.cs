namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Clase que relaciona una persona con el perfil (Voluntario, Colaborador, ...)
    /// </summary>
    public partial class personas_perfiles
    {

        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public personas_perfiles()
        {

        }

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="id">ID Autoincremental para cada registro de la base de datos</param>
        /// <param name="idPersona">Referencia a la persona con su id de persona</param>
        /// <param name="idPerfil">Referencia al perfil con su id de perfil</param>
        public personas_perfiles(int id, int idPersona, int idPerfil)
        {
            this.id = id;
            this.idPersona = idPersona;
            this.idPerfil = idPerfil;
        }

        #endregion

        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// ID Autoincremental para cada registro de la base de datos
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Referencia a la persona con su id de persona
        /// </summary>
        public int idPersona { get; set; }

        /// <summary>
        /// Referencia al perfil con su id de perfil
        /// </summary>
        public int idPerfil { get; set; }
    
        public virtual perfiles perfiles { get; set; }
        public virtual personas personas { get; set; }

        #endregion
    }
}
