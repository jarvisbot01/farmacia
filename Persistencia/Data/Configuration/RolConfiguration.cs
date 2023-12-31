using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("rol");

        builder.Property(e => e.Nombre).HasColumnName("nombre").IsRequired();

        builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsRequired();

        builder
            .Property(e => e.CreatedAt)
            .HasColumnName("createdAt")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
    }
}
