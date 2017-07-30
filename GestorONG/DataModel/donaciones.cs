namespace GestorONG.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Clase que hereda de persona para almacenar la información de un colaborador
    /// </summary> 
    public partial class donaciones
    {

        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public donaciones()
        {

        }

        /// <summary>
        /// Constructor por parámetros de donaciones
        /// </summary>
        /// <param name="id">ID autoincremental del registro de la BBDD.</param>
        /// <param name="cantidad">Float que representa la cantidad de la donación.</param>
        /// <param name="fechaAlta">Fecha de alta de la donación.</param>
        /// <param name="idColaborador">Id del colaborador que ha hecho la donación.</param>
        /// <param name="idPeriodicidad">Id de la periodicidad de la donación (mensual, trimestral, ...).</param>
        public donaciones (int id, float cantidad, DateTime fechaAlta, int idColaborador, int idPeriodicidad)
        {
            this.id = id;
            this.cantidad = cantidad;
            this.fechaAlta = fechaAlta;
            this.idColaborador = idColaborador;
            this.idPeriodicidad = idPeriodicidad;
        }

        #endregion

        #region PUBLIC_MEMBER_VARIABLES

        public int id { get; set; }
        /// <summary>
        /// Float que representa la cantidad de la donación.
        /// </summary>
        public float cantidad { get; set; }
        /// <summary>
        /// Fecha de alta de la donación.
        /// </summary>
        public System.DateTime fechaAlta { get; set; }
        /// <summary>
        /// Id del colaborador que ha hecho la donación.
        /// </summary>
        public int idColaborador { get; set; }
        /// <summary>
        /// Id de la periodicidad de la donación (mensual, trimestral, ...).
        /// </summary>
        public int idPeriodicidad { get; set; }
    
        public virtual colaboradores colaboradores { get; set; }
        public virtual periodicidades periodicidades { get; set; }

        #endregion
    }
}
