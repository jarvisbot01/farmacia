using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("venta");

        builder
            .HasOne(v => v.Cliente)
            .WithMany(c => c.Ventas)
            .HasForeignKey(v => v.IdClienteFk)
            .IsRequired();

        builder
            .HasOne(v => v.Empleado)
            .WithMany(e => e.Ventas)
            .HasForeignKey(v => v.IdEmpleadoFk)
            .IsRequired();

        builder
            .Property(v => v.CreatedAt)
            .HasColumnName("createdAt")
            .HasDefaultValueSql("now()")
            .IsRequired();
    }
}
