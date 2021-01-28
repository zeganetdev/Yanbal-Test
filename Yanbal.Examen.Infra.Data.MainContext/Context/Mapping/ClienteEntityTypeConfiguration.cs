using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yanbal.Examen.Domain.MainContext.Aggregates.ClienteAgg;

namespace Yanbal.Examen.Infra.Data.MainContext.Context.Mapping
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombres);
            builder.Property(x => x.Apellidos);
            builder.HasIndex(x => x.Correo).IsUnique();
            builder.Property(x => x.Correo);
            builder.Property(x => x.FechaNacimiento).HasDefaultValue(null);
            builder.Property(x => x.Direccion);
            builder.Property(x => x.Activo);
            builder.Property(x => x.FechaRegistro);
        }
    }
}
