using GestorONG.DataModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Linq;

namespace GestorONG.DAL
{
    /// <summary>
    /// Clase del tipo Data Access Layer  o conocida como database context class para acceder a la base de datos. Hereda de DbContext
    /// </summary>
    public class GestorONGDContext : DbContext
    {
        #region PUBLIC_MEMBER_METHODS

        /// <summary>
        /// Constructor por defecto. Se le pasa el connection string name para conectarse a la base de datos definido en el archivo Web.config
        /// </summary>
        public GestorONGDContext() : base(ConfigurationManager.ConnectionStrings["gestor_ongd_sps_prodEntities"].ConnectionString)
        {
        }

        #endregion

        #region PROTECTED_MEMBER_METHODS

        /// <summary>
        /// Sobreescribe el comportamiento del constructor del modelo para eliminar la convencion de poner en plurar los nombres de las tablas
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<voluntarios>().ToTable("voluntarios");
            modelBuilder.Entity<colaboradores>().ToTable("colaboradores");
        }

        #endregion

        #region PUBLIC_MEMBER_VARIABLES

        /// <summary>
        /// Database set para obtener / introducir datos de los voluntarios en la base de datos
        /// </summary>
        public DbSet<voluntarios> voluntarios { get; set; }

        /// <summary>
        /// Database set para obtener / introducir datos de las personas en la base de datos
        /// </summary>
        public DbSet<personas> persona { get; set; }

        /// <summary>
        /// Database set para obtener / introducir datos de las sedes delegaciones en la base de datos
        /// </summary>
        public DbSet<sede_delegacion> sedes_delegaciones { get; set; }

        /// <summary>
        /// Database set para obtener / introducir datos de los perfiles en la base de datos
        /// </summary>
        public DbSet<perfiles> perfil { get; set; }

        /// <summary>
        /// Database set para obtener / introducir datos de las personas y perfiles en la base de datos
        /// </summary>
        public DbSet<personas_perfiles> persona_perfil { get; set; }

        public System.Data.Entity.DbSet<GestorONG.DataModel.colaboradores> colaboradores { get; set; }

        public System.Data.Entity.DbSet<GestorONG.DataModel.vistaColaboradores> vistaColaboradores { get; set; }

        public DbSet<periodicidades> periodicidades { get; set; }

        public DbSet<donaciones> donaciones { get; set; }

        public System.Data.Entity.DbSet<GestorONG.DataModel.voluntario> voluntario { get; set; }

        #endregion

        #region

        /// <summary>
        /// Captura las excepciones a la hora de validar los datos
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }


        #endregion

        public System.Data.Entity.DbSet<GestorONG.ViewModel.CertificadoViewModel> CertificadoViewModels { get; set; }
    }
}