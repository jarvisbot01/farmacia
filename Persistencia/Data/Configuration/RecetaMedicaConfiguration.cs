using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class RecetaMedicaConfiguration : IEntityTypeConfiguration<RecetaMedica>
{
    public void Configure(EntityTypeBuilder<RecetaMedica> builder)
    {
        builder.ToTable("recetaMedica");

        builder.Property(r => r.Token).HasColumnName("token").IsRequired();

        builder.Property(r => r.Detalle).HasColumnName("detalle").IsRequired();

        builder.Property(r => r.FechaEmision).HasColumnName("fechaEmision").IsRequired();

        builder
            .Property(r => r.CreatedAt)
            .HasColumnName("createdAt")
            .IsRequired()
            .HasDefaultValueSql("now()");

        builder
            .HasOne(r => r.Cliente)
            .WithMany(c => c.RecetasMedicas)
            .HasForeignKey(r => r.IdClienteFk)
            .IsRequired();
    }
}
