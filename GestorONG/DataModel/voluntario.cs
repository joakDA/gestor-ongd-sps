//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class voluntario
    {
        public int id { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Apellidos")]
        public string apellidos { get; set; }
        [DisplayName("Dirección")]
        public string direccionPostal { get; set; }
        [DisplayName("CP")]
        public string codigoPostal { get; set; }
        [DisplayName("Localidad")]
        public string localidad { get; set; }
        [DisplayName("Provincia")]
        public string provincia { get; set; }
        [DisplayName("País")]
        public string pais { get; set; }
        [DisplayName("Teléfono")]
        public string telefono1 { get; set; }
        [DisplayName("Teléfono 2")]
        public string telefono2 { get; set; }
        [DisplayName("E-mail")]
        public string email { get; set; }
        [DisplayName("Fecha Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        [DisplayName("Fecha Alta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime fechaAlta { get; set; }
        public string Sede { get; set; }
        public string Perfiles { get; set; }
    }
}