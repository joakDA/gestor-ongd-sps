namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class voluntario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string direccionPostal { get; set; }
        public string codigoPostal { get; set; }
        public string localidad { get; set; }
        public string provincia { get; set; }
        public string pais { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public System.DateTime fechaAlta { get; set; }
        public string Sede { get; set; }
        public string Perfiles { get; set; }
    }
}
