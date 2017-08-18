
// Copyright (c) Joaquín Alejandro Duro Arribas.
// Licensed under the MIT License, See License in the project root for license information.

namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase perteneciente a la vista que obtiene los datos de un colaborador.
    /// </summary>
    public partial class vistaColaboradores
    {
        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// ID Autoincremental de la persona.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        [DisplayName("Nombre")]
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }
        /// <summary>
        /// Apellidos de una persona.
        /// </summary>
        [DisplayName("Apellidos")]
        [Required]
        [StringLength(100)]
        public string apellidos { get; set; }
        /// <summary>
        /// Dirección postal de la persona.
        /// </summary>
        [DisplayName("Dirección")]
        [Required]
        [StringLength(150)]
        public string direccionPostal { get; set; }
        /// <summary>
        /// Codigo postal de la dirección postal de la persona.
        /// </summary>
        [DisplayName("CP")]
        [Required]
        [StringLength(5)]
        public string codigoPostal { get; set; }
        /// <summary>
        /// Localidad de la persona.
        /// </summary>
        [DisplayName("Localidad")]
        [Required]
        [StringLength(75)]
        public string localidad { get; set; }
        /// <summary>
        /// Provincia correspondiente a la localidad de una persona.
        /// </summary>
        [DisplayName("Provincia")]
        [Required]
        [StringLength(75)]
        public string provincia { get; set; }
        /// <summary>
        /// Pais de la dirección postal de la persona.
        /// </summary>
        [DisplayName("País")]
        [Required]
        [StringLength(100)]
        public string pais { get; set; }
        /// <summary>
        /// Teléfono de contacto de la persona.
        /// </summary>
        [DisplayName("Teléfono")]
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
        [DisplayName("E-mail")]
        [Required]
        [StringLength(150)]
        public string email { get; set; }
        /// <summary>
        /// Fecha de Nacimiento de la persona. Valor opcional no requerido en los formularios.
        /// </summary>
        [DisplayName("Fecha Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
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
        /// <summary>
        /// Perfiles que tiene asociada una persona (Voluntario, Colaborador).
        /// </summary>

        public string Perfiles { get; set; }
        /// <summary>
        /// Cantidad total (en €) de dinero que dona a la organización.
        /// </summary>
        [DisplayName("Cantidad")]
        [Required]
        public Single cantidad { get; set; }
        /// <summary>
        /// Fecha en que inició la colaboración mediante donativos con la organización.
        /// </summary>
        [DisplayName("Fecha Alta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime fechaAlta { get; set; }
        /// <summary>
        /// Indica cada cuánto tiempo se debe pasar el cargo por el importe de la donación. Utilizado para la generación de remesas bancarias.
        /// </summary>
        [DisplayName("Periodicidad")]
        [Required]
        public string Periodicidad { get; set; }

        #endregion
    }
}
