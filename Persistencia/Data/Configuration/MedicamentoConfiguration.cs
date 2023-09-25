using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable("medicamento");

        builder.Property(m => m.Nombre).HasColumnName("nombre").IsRequired();

        builder.Property(m => m.Concentracion).HasColumnName("concentracion").IsRequired();

        builder.Property(m => m.Precio).HasColumnName("precio").IsRequired();

        builder.Property(m => m.Stock).HasColumnName("stock").IsRequired();

        builder
            .Property(m => m.Contraindicaciones)
            .HasColumnName("contraindicaciones")
            .IsRequired();

        builder.Property(m => m.DosisRecomendada).HasColumnName("dosisRecomendada").IsRequired();

        builder.Property(m => m.FechaExpedicion).HasColumnName("fechaExpedicion").IsRequired();

        builder
            .Property(m => m.CreatedAt)
            .HasColumnName("createdAt")
            .HasDefaultValueSql("now()")
            .IsRequired();
    }
}
