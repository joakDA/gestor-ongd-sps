using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorONG.Models
{
    /// <summary>
    /// Clase que hereda de persona para almacenar la información de un voluntario
    /// </summary>
    public class Voluntario : Persona
    {
        #region PUBLIC_MEMBER_VARIABLES
        /// <summary>
        /// Id autoincremental de la base de datos del voluntario
        /// </summary>
        public int idVoluntario { get; set; }

        /// <summary>
        /// Fecha de alta del voluntario en la base de datos
        /// </summary>
        public DateTime fechaAlta { get; set; }

        /// <summary>
        /// Almacena el nombre de la sede a la que pertenece el voluntario
        /// </summary>
        public string sede { get; set; }

        #endregion

        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Voluntario() : base()
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
        /// <param name="idVoluntario">ID autoincrmental del voluntario</param>
        /// <param name="fechaAlta">Fecha de alta del voluntario en la base de datos</param>
        /// <param name="sede">Almacena el nombre de la sede a la que pertenece el voluntario</param>
        public Voluntario(int ident, string name, string lastName, string postalAddress, string postalCode, string city, string state, string country, string phone1, string phone2, 
            string emailAddress, DateTime birthDate,int idVoluntario, DateTime fechaAlta, string sede) : base 
            (ident, name, lastName, postalAddress, postalCode, city, state, country, phone1, phone2, emailAddress, birthDate)
        {
            this.idVoluntario = idVoluntario;
            this.fechaAlta = fechaAlta;
            this.sede = sede;
        }

        #endregion
    }
}