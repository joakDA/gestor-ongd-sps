namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Modelo para almacenar los datos de la vista de voluntarios
    /// </summary>
    public partial class voluntario
    {

        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public voluntario()
        {
        }

        /// <summary>
        /// Constructor por parámetros de Voluntarios. Hereda de Persona
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
        /// <param name="fechaAlta">Fecha de alta del voluntario en la base de datos</param>
        /// <param name="sede">Almacena el nombre de la sede a la que pertenece el voluntario</param>
        /// <param name="profiles">Contiene los perfiles del usuario</param>
        public voluntario(int ident, string name, string lastName, string postalAddress, string postalCode, string city, string state, string country, string phone1, string phone2,
            string emailAddress, DateTime birthDate, DateTime fechaAlta, string sede,string profiles)
        {
            this.id = ident;
            this.nombre = name;
            this.apellidos = lastName;
            this.direccionPostal = postalAddress;
            this.codigoPostal = postalCode;
            this.localidad = city;
            this.provincia = state;
            this.pais = country;
            this.telefono1 = phone1;
            this.telefono2 = phone2;
            this.email = emailAddress;
            this.fechaNacimiento = birthDate;
            this.fechaAlta = fechaAlta;
            this.Sede = sede;
            this.Perfiles = profiles;
        }
        
        #endregion


        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// ID Autoincremental de la persona<
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nombre de la persona
        /// </summary>
        public string nombre { get; set; }

        /// <summary>
        /// Apellidos de una persona
        /// </summary>
        public string apellidos { get; set; }

        /// <summary>
        /// Dirección postal de la persona
        /// </summary>
        public string direccionPostal { get; set; }

        /// <summary>
        /// Código postal de la dirección postal de la persona
        /// </summary>
        public string codigoPostal { get; set; }

        /// <summary>
        /// Localidad de la persona
        /// </summary>
        public string localidad { get; set; }

        /// <summary>
        /// Provincia correspondiente a la localidad de una persona
        /// </summary>
        public string provincia { get; set; }

        /// <summary>
        /// País de la dirección postal de la persona
        /// </summary>
        public string pais { get; set; }

        /// <summary>
        /// Teléfono de contacto de la persona
        /// </summary>
        public string telefono1 { get; set; }

        /// <summary>
        /// Teléfono de contacto secundario de la persona. Valor opcional y no requerido en los formularios.
        /// </summary>
        public string telefono2 { get; set; }

        /// <summary>
        /// Dirección de correo electrónico de la persona.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Fecha de Nacimiento de la persona. Valor opcional no requerido en los formularios.
        /// </summary>
        public Nullable<System.DateTime> fechaNacimiento { get; set; }

        /// <summary>
        /// Fecha de alta del voluntario en la base de datos
        /// </summary>
        public System.DateTime fechaAlta { get; set; }

        /// <summary>
        /// Almacena el nombre de la sede a la que pertenece el voluntario
        /// </summary>
        public string Sede { get; set; }

        /// <summary>
        /// Contiene el/los perfi/les que tenga el usuario
        /// </summary>
        public string Perfiles { get; set; }

        #endregion
    }
}
