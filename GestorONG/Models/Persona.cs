using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorONG.Models
{
    /// <summary>
    /// Clase Persona conteniendo los atributos comunes de los Voluntarios y Colaboradores. Heredarán de esta clase, la clase Voluntario y Colaborador.
    /// </summary>
    public abstract class Persona
    {
        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// ID Autoincremental de la persona
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
        /// Codigo postal de la dirección postal de la persona
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
        /// Pais de la dirección postal de la persona
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
        public DateTime fechaNacimiento { get; set; }

        #endregion

        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public Persona() { }

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
        public Persona(int id, string nombre, string apellidos, string direccionPostal, string codigoPostal, string localidad, string provincia, string pais, string telefono1, string telefono2,
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
        }

        #endregion
    }
}