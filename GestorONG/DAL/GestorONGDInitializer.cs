using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GestorONG.DataModel;

namespace GestorONG.DAL
{
    /// <summary>
    /// Clase para inicializar las tablas de la base de datos con datos iniciales. Hereda de Entity Framework para que si el modelo cambia, se elimine la base de datos y se vuelva a crear.
    /// Cuando el sistema esté en producción, se añadirá un atributo en el Web.config para que ignore este inicializador.
    /// </summary>
    public class GestorONGDInitializer : IDatabaseInitializer<GestorONGDContext>
    {

        #region PROTECTED_MEMBER_METHODS

        /// <summary>
        /// Método para ir alimentando la base de datos con datos de muestra
        /// The Seed method takes the database context object as an input parameter, and the code in the method uses that object to add new entities to the database.
        /// For each entity type, the code creates a collection of new entities, adds them to the appropriate DbSet property, and then saves the changes to the database.
        /// </summary>
        /// <param name="context"></param>
        public void InitializeDatabase(GestorONGDContext context)
        {
            //Sedes-Delegaciones
            var sede = new List<sede_delegacion>
            {
                new sede_delegacion { nombre="Sede Central", direccion="C/Cardenal Marcelo Spínola, 34", codigoPostal="28016", localidad = "Madrid", provincia = "Madrid", pais = "España",
                    personaContacto="Juan Pérez García", emailContacto="info@spinolasolidaria.org", telefonoContacto="91 827 66 81" },
                new sede_delegacion {nombre="Delegación Málaga", direccion="C/Dirección de Málaga, S/N", codigoPostal="29070", localidad = "Málaga", provincia = "Málaga", pais = "España",
                    personaContacto="Lucía Sánchez Sánchez", emailContacto="informatica@spinolasolidaria.org", telefonoContacto="670 91 35 07"}
            };
            //Se recorre la lista y se añade cada elemento a la base de datos
            sede.ForEach(s => context.sedes_delegaciones.Add(s));
            context.SaveChanges();

            //Voluntarios
            var voluntario = new List<voluntarios>
            {
                new voluntarios { nombre="Joaquín Alejandro", apellidos="Duro Arribas", direccionPostal="Dirección de prueba", codigoPostal="28029", localidad="Madrid", provincia="Madrid",
                pais="España",telefono1="676123456", email="joaquin.duro@gmail.com", fechaNacimiento=DateTime.Parse("1989-01-01"), fechaAlta=DateTime.Today, sede=1},
                new voluntarios { nombre="Laura", apellidos="García Sánchez", direccionPostal="Dirección de prueba 2", codigoPostal="29071", localidad="Málaga", provincia="Málaga",
                pais="España",telefono1="123456789", email="example@example.com", fechaNacimiento=DateTime.Parse("1976-05-10"), fechaAlta=DateTime.Today, sede=2}
            };
            //Se recorre la lista y se añade cada elemento a la base de datos
            voluntario.ForEach(s => context.voluntarios.Add(s));
            context.SaveChanges();

            //Perfiles
            var perfil = new List<perfiles>
            {
                new perfiles {nombre="Voluntario" },
                new perfiles {nombre="Colaborador" },
                new perfiles {nombre="Profesor/a" },
                new perfiles {nombre="Religiosa" },
                new perfiles {nombre="Superiora" },
                new perfiles {nombre="Delegada" },
                new perfiles {nombre="Director/a" }
            };

            //Se recorre la lista y se añade cada elemento a la base de datos
            perfil.ForEach(s => context.perfil.Add(s));
            context.SaveChanges();

            //Personas-Perfiles
            var persona_perfil = new List<personas_perfiles>
            {
                new personas_perfiles {idPersona=1,idPerfil=1 },
                new personas_perfiles {idPersona=1, idPerfil=3 },
                new personas_perfiles {idPersona=2, idPerfil=1 }
            };

            //Se recorre la lista y se añade cada elemento a la base de datos
            persona_perfil.ForEach(s => context.persona_perfil.Add(s));
            context.SaveChanges();
        }

        #endregion


    }
}