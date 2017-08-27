namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase Persona conteniendo los atributos comunes de los Voluntarios y Colaboradores. Heredarán de esta clase, la clase Voluntario y Colaborador.
    /// </summary>
    public class personas
    {
        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personas()
        {
            this.personas_perfiles = new HashSet<personas_perfiles>();
            this.colaboradores = new HashSet<colaboradores>();
            this.voluntarios = new HashSet<voluntarios>();
        }

        /// <summary>
        /// Constructor por parámetros
        /// </summary>
        /// <param name="id">Id de la persona autoincremental</param>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellidos">Apellidos de la persona</param>
        /// <param name="direccionPostal">Dirección postal de la persona</param>
        /// <param name="codigoPostal">Codigo postal de la dirección postal de la persona</param>
        /// <param name="localidad">Localidad de la persona</param>
        /// <param name="provincia">Provincia correspondiente a la localidad de una persona</param>
        /// <param name="pais">Pais de la dirección postal de la persona</param>
        /// <param name="telefono1">Teléfono de contacto de la persona</param>
        /// <param name="telefono2">Teléfono de contacto secundario de la persona. Valor opcional y no requerido en los formularios.</param>
        /// <param name="email">Dirección de correo electrónico de la persona.</param>
        /// <param name="fechaNacimiento">Fecha de Nacimiento de la persona. Valor opcional no requerido en los formularios.</param>
        public personas(int id, string nombre, string apellidos, string direccionPostal, string codigoPostal, string localidad, string provincia, string pais, string telefono1, string telefono2,
            string email, DateTime fechaNacimiento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccionPostal = direccionPostal;
            this.codigoPostal = codigoPostal;
            this.localidad = localidad;
            this.provincia = provincia;
            this.pais = pais;
            this.telefono1 = telefono1;
            this.telefono2 = telefono2;
            this.email = email;
            this.fechaNacimiento = fechaNacimiento;
            this.personas_perfiles = new HashSet<personas_perfiles>();
            this.colaboradores = new HashSet<colaboradores>();
            this.voluntarios = new HashSet<voluntarios>();
        }

        /// <summary>
        /// Constructor que crea una persona a partir de una ya existente.
        /// </summary>
        /// <param name="persona">Objeto de la clase personas a copiar</param>
        public personas(personas persona)
        {
            this.id = persona.id;
            this.nombre = persona.nombre;
            this.apellidos = persona.apellidos;
            this.direccionPostal = persona.direccionPostal;
            this.codigoPostal = persona.codigoPostal;
            this.localidad = persona.localidad;
            this.provincia = persona.provincia;
            this.pais = persona.pais;
            this.telefono1 = persona.telefono1;
            this.telefono2 = persona.telefono2;
            this.email = persona.email;
            this.fechaNacimiento = persona.fechaNacimiento;
            this.personas_perfiles = persona.personas_perfiles;
            this.colaboradores = persona.colaboradores;
            this.voluntarios = persona.voluntarios;
        }

        #endregion

        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// ID Autoincremental de la persona
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nombre de la persona
        /// </summary>
        [DisplayName("Nombre")]
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        /// <summary>
        /// Apellidos de una persona
        /// </summary>
        [DisplayName("Apellidos")]
        [Required]
        [StringLength(100)]
        public string apellidos { get; set; }

        /// <summary>
        /// Dirección postal de la persona
        /// </summary>
        [DisplayName("Dirección")]
        [Required]
        [StringLength(150)]
        public string direccionPostal { get; set; }

        /// <summary>
        /// Codigo postal de la dirección postal de la persona
        /// </summary>
        [DisplayName("CP")]
        [Required]
        [StringLength(5)]
        public string codigoPostal { get; set; }

        /// <summary>
        /// Localidad de la persona
        /// </summary>
        [DisplayName("Localidad")]
        [Required]
        [StringLength(75)]
        public string localidad { get; set; }

        /// <summary>
        /// Provincia correspondiente a la localidad de una persona
        /// </summary>
        [DisplayName("Provincia")]
        [Required]
        [StringLength(75)]
        public string provincia { get; set; }

        /// <summary>
        /// Pais de la dirección postal de la persona
        /// </summary>
        [DisplayName("País")]
        [Required]
        [StringLength(100)]
        public string pais { get; set; }

        /// <summary>
        /// Teléfono de contacto de la persona
        /// </summary>
        [DisplayName("Teléfono 1")]
        [Required]
        [StringLength(15)]
        public string telefono1 { get; set; }

        /// <summary>
        /// Teléfono de contacto secundario de la persona. Valor opcional y no requerido en los formularios.
        /// </summary>
        [DisplayName("Teléfono 2")]
        [StringLength(15)]
        public string telefono2 { get; set; }

        /// <summary>
        /// Dirección de correo electrónico de la persona.
        /// </summary>
        [DisplayName("Email")]
        [Required]
        [StringLength(150)]
        public string email { get; set; }

        /// <summary>
        /// Fecha de Nacimiento de la persona. Valor opcional no requerido en los formularios.
        /// </summary>
        [DisplayName("Fecha de Nacimiento")]
        [Required]
        public Nullable<System.DateTime> fechaNacimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personas_perfiles> personas_perfiles { get; set; }

        public virtual ICollection<colaboradores> colaboradores { get; set; }

        public virtual ICollection<voluntarios> voluntarios { get; set; }

        #endregion


    }
}