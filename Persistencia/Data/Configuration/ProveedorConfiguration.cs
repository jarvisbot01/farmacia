using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("proveedor");

        builder.Property(e => e.Nombre).HasColumnName("nombre").IsRequired();

        builder.Property(e => e.Direccion).HasColumnName("direccion").IsRequired();

        builder.Property(e => e.Telefono).HasColumnName("telefono").IsRequired();

        builder.Property(e => e.Email).HasColumnName("email").IsRequired();

        builder.Property(e => e.CreatedAt).HasColumnName("createdAt");

        builder.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
    }
}
