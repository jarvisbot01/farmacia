using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class LoteConfiguration : IEntityTypeConfiguration<Lote>
{
    public void Configure(EntityTypeBuilder<Lote> builder)
    {
        builder.ToTable("lote");

        builder.Property(l => l.FechaVencimiento).HasColumnName("fechaVencimiento").IsRequired();

        builder.Property(l => l.Cantidad).HasColumnName("cantidad").IsRequired();

        builder.Property(l => l.PrecioUnitario).HasColumnName("precioUnitario").IsRequired();

        builder.Property(l => l.PrecioCompra).HasColumnName("precioCompra").IsRequired();

        builder.Property(l => l.CreatedAt).HasColumnName("createdAt").IsRequired();

        builder.Property(l => l.UpdatedAt).HasColumnName("updatedAt").IsRequired();

        builder
            .HasOne(l => l.Medicamento)
            .WithMany(m => m.Lotes)
            .HasForeignKey(l => l.IdMedicamentoFk);

        builder.HasOne(l => l.Compra).WithMany(c => c.Lotes).HasForeignKey(l => l.IdCompraFk);
    }
}
