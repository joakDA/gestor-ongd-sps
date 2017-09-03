namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Clase que hereda de persona para almacenar la información de un colaborador
    /// </summary>
    [Table("colaboradores")]
    public partial class colaboradores : personas
    {
        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public colaboradores() : base()
        {
            this.donaciones = new HashSet<donaciones>();
        }

        /// <summary>
        /// Constructor por parámetros de Colaboradores. Hereda de Persona
        /// </summary>
        /// <param name="ident">ID Autoincremental de la persona</param>
        /// <param name="name">Nombre de la persona</param>
        /// <param name="lastName">Apellidos de una persona</param>
        /// <param name="postalAddress">Dirección postal de la persona</param>
        /// <param name="postalCode">Codigo postal de la dirección postal de la persona</param>
        /// <param name="city">Localidad de la persona</param>
        /// <param name="state">Provincia correspondiente a la localidad de una persona</param>
        /// <param name="country">Pais de la dirección postal de la persona</param>
        /// <param name="phone1">Teléfono de contacto de la persona</param>
        /// <param name="phone2">Teléfono de contacto secundario de la persona. Valor opcional y no requerido en los formularios.</param>
        /// <param name="emailAddress">Dirección de correo electrónico de la persona.</param>
        /// <param name="birthDate">Fecha de Nacimiento de la persona. Valor opcional no requerido en los formularios.</param>
        /// <param name="CIF_NIF">Número de identificación fiscal de la persona o empresa que es colaborador.</param>
        /// <param name="cuentaBancaria">Cuenta bancaria a dónde se realizarán los cargos de las donaciones.</param>
        
        public colaboradores(int ident, string name, string lastName, string postalAddress, string postalCode, string city, string state, string country, string phone1, string phone2,
            string emailAddress, DateTime birthDate, string CIF_NIF, string cuentaBancaria) : base
            (ident, name, lastName, postalAddress, postalCode, city, state, country, phone1, phone2, emailAddress, birthDate)
        {
            this.CIF_NIF = CIF_NIF;
            this.CuentaBancaria = cuentaBancaria;
            this.donaciones = new HashSet<donaciones>();
        }

        /// <summary>
        /// Constructor con parámetros para crear el colaborador cuando existe la donación.
        /// </summary>
        /// <param name="persona">Objeto de la clase persona.</param>
        /// <param name="CIF_NIF">CIF o NIF de la persona que realiza la donación (se convierte en colaborador).</param>
        /// <param name="cuentaBancaria">Cuenta bancaria a la que se emitirán las remesas bancarias</param>
        /*public colaboradores(personas persona, string CIF_NIF, string cuentaBancaria) : base(persona)
        {
            this.CIF_NIF = CIF_NIF;
            this.CuentaBancaria = cuentaBancaria;
            this.donaciones = new HashSet<donaciones>();
        }*/

        public colaboradores (personas persona, string CIF_NIF, string cuentaBancaria)
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
            this.CIF_NIF = CIF_NIF;
            this.CuentaBancaria = cuentaBancaria;
        }

        #endregion

        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// Id autoncremental del colaborador. Lo genera la BBDD.
        /// </summary>
        public int idColaborador { get; set; }
        /// <summary>
        /// Número de identificación fiscal de la persona o empresa que es colaborador.
        /// </summary>
        [DisplayName("CIF/NIF")]
        [Required]
        [StringLength(9)]
        public string CIF_NIF { get; set; }
        /// <summary>
        /// Cuenta bancaria a dónde se realizarán los cargos de las donaciones.
        /// </summary>
        [DisplayName("Cuenta Bancaria")]
        [Required]
        [StringLength(24)]
        public string CuentaBancaria { get; set; }
    
        public virtual personas personas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donaciones> donaciones { get; set; }

        #endregion
    }
}
