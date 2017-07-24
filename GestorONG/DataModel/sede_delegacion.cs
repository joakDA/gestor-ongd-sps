namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    /// <summary>
    /// Clase para almacenar los datos de una sede/delegación
    /// </summary>
    public partial class sede_delegacion
    {
        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sede_delegacion()
        {
            this.voluntarios = new HashSet<voluntarios>();
        }

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="id">ID Autoincremental de la sede o delegación</param>
        /// <param name="nombre">Nombre de la delegación</param>
        /// <param name="direccion">Dirección postal de la delegación</param>
        /// <param name="codigoPostal">Código postal de la delegación</param>
        /// <param name="localidad">Localidad dónde está ubicada la sede o delegación</param>
        /// <param name="provincia">Provincia de la localidad de la sede</param>
        /// <param name="pais">País en el que se encuentra la sede o delegación</param>
        /// <param name="personaContacto">Persona de contacto por la que preguntar de la sede o delegación</param>
        /// <param name="emailContacto">Email de contacto de la sede o delegación para contactar con la persona de contacto</param>
        /// <param name="telefonoContacto">Teléfono de contacto de la sede o delegación para contactar con la persona de contacto</param>
        public sede_delegacion(int id, string nombre, string direccion, string codigoPostal, string localidad, string provincia, string pais, string personaContacto, string emailContacto, string telefonoContacto)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.codigoPostal = codigoPostal;
            this.localidad = localidad;
            this.provincia = provincia;
            this.pais = pais;
            this.personaContacto = personaContacto;
            this.emailContacto = emailContacto;
            this.telefonoContacto = telefonoContacto;
        }

        #endregion

        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// ID Autoincremental de la sede o delegación
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nombre de la delegación
        /// </summary>
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        /// <summary>
        /// Dirección postal de la delegación
        /// </summary>
        [DisplayName("Direccion")]
        public string direccion { get; set; }

        /// <summary>
        /// Código postal de la delegación
        /// </summary>
        [DisplayName("CP")]
        public string codigoPostal { get; set; }

        /// <summary>
        /// Localidad dónde está ubicada la sede o delegación
        /// </summary>
        [DisplayName("Localidad")]
        public string localidad { get; set; }

        /// <summary>
        /// Provincia de la localidad de la sede
        /// </summary>
        [DisplayName("Provincia")]
        public string provincia { get; set; }

        /// <summary>
        /// País en el que se encuentra la sede o delegación
        /// </summary>
        [DisplayName("País")]
        public string pais { get; set; }

        /// <summary>
        /// Persona de contacto por la que preguntar de la sede o delegación
        /// </summary>
        [DisplayName("Persona de Contacto")]
        public string personaContacto { get; set; }

        /// <summary>
        /// Email de contacto de la sede o delegación para contactar con la persona de contacto
        /// </summary>
        [DisplayName("Email de Contacto")]
        public string emailContacto { get; set; }

        /// <summary>
        /// Teléfono de contacto de la sede o delegación para contactar con la persona de contacto
        /// </summary>
        [DisplayName("Teléfono de Contacto")]
        public string telefonoContacto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<voluntarios> voluntarios { get; set; }

        #endregion
    }
}
