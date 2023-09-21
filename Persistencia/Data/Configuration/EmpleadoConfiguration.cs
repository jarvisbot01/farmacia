using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");

        builder.Property(e => e.Cedula).HasColumnName("cedula").IsRequired();

        builder.Property(e => e.Nombre).HasColumnName("nombre").IsRequired();

        builder.Property(e => e.Direccion).HasColumnName("direccion").IsRequired();

        builder.Property(e => e.Telefono).HasColumnName("telefono").IsRequired();

        builder.Property(e => e.Email).HasColumnName("email").IsRequired();

        builder.Property(e => e.CreatedAt).HasColumnName("createdAt").IsRequired();

        builder.HasOne(e => e.Rol)
            .WithMany(r => r.Empleados)
            .HasForeignKey(e => e.RolIdFk);
    }
}
