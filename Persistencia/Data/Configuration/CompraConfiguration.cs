using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.ToTable("Compra");

        builder.Property(c => c.FechaCompra).HasColumnName("fechaCompra").IsRequired();

        builder.Property(c => c.PrecioTotal).HasColumnName("precioTotal").IsRequired();

        builder.Property(c => c.CreatedAt).HasColumnName("createdAt").IsRequired();

        builder
            .HasOne(c => c.Proveedor)
            .WithMany(p => p.Compras)
            .HasForeignKey(c => c.IdProveedorFk);
    }
}
