using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("detalleVenta");

        builder.Property(e => e.Cantidad).HasColumnName("cantidad").IsRequired();

        builder.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario").IsRequired();

        builder.Property(e => e.Subtotal).HasColumnName("subtotal").IsRequired();

        builder
            .Property(e => e.CreatedAt)
            .HasColumnName("createdAt")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

        builder
            .HasOne(d => d.Venta)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(d => d.IdVentaFk)
            .IsRequired();

        builder
            .HasOne(d => d.Medicamento)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(d => d.IdMedicamentoFk)
            .IsRequired();

        builder
            .HasOne(d => d.Lote)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(d => d.IdLoteFk)
            .IsRequired();
    }
}
