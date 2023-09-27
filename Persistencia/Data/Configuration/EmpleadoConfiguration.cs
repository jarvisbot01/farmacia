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

        builder.Property(e => e.Password).HasColumnName("password").IsRequired();

        builder
            .Property(e => e.CreatedAt)
            .HasColumnName("createdAt")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder
            .HasMany(e => e.Roles)
            .WithMany(r => r.Empleados)
            .UsingEntity<EmpleadoRol>(
                j =>
                    j.HasOne(er => er.Rol)
                        .WithMany(r => r.EmpleadoRoles)
                        .HasForeignKey(er => er.IdRolFk),
                j =>
                    j.HasOne(er => er.Empleado)
                        .WithMany(e => e.EmpleadoRoles)
                        .HasForeignKey(er => er.IdEmpleadoFk),
                j =>
                {
                    j.ToTable("empleadoRol");
                    j.HasKey(er => new { er.IdEmpleadoFk, er.IdRolFk });
                    j.Property(er => er.IdEmpleadoFk).HasColumnName("idEmpleadoFk");
                    j.Property(er => er.IdRolFk).HasColumnName("idRolFk");
                }
            );

        builder
            .HasMany(e => e.RefreshTokens)
            .WithOne(rt => rt.Empleado)
            .HasForeignKey(rt => rt.IdEmpleadoFk)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
