using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Yanbal.Examen.Domain.MainContext.Aggregates.ClienteAgg;
using Yanbal.Examen.Infra.Data.MainContext.Context.Mapping;

namespace Yanbal.Examen.Infra.Data.MainContext.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        #region IDbSet Members

        public virtual DbSet<Cliente> Clientes { get; set; }

        #endregion

        #region Model Creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfiguration());


            modelBuilder.Entity<Cliente>()
            .HasData(
                new Cliente { Id = 1, Nombres = "Carlos", Apellidos = "Alcantara", Correo = "carlos@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new Cliente { Id = 2, Nombres = "Luis", Apellidos = "Reyes", Correo = "luis@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new Cliente { Id = 3, Nombres = "Marcos", Apellidos = "Pinillos", Correo = "marcos1@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new Cliente { Id = 4, Nombres = "Marcos", Apellidos = "Buis", Correo = "marcos2@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true },
                new Cliente { Id = 5, Nombres = "Alberto", Apellidos = "Coronel", Correo = "alberto@dominio.com", FechaNacimiento = null, FechaRegistro = DateTime.Now, Activo = true }
            );


            SetNotDeleteCascade(modelBuilder);
        }

        private void SetNotDeleteCascade(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        #endregion
    }
}
