using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");

        builder.Property(c => c.Cedula).HasColumnName("cedula").IsRequired();

        builder.Property(c => c.Nombre).HasColumnName("nombre");

        builder.Property(c => c.Direccion).HasColumnName("direccion");

        builder.Property(c => c.Telefono).HasColumnName("telefono");

        builder.Property(c => c.Email).HasColumnName("email");

        builder.Property(c => c.EstaRegistrado).HasColumnName("estaRegistrado").IsRequired();

        builder
            .Property(c => c.CreatedAt)
            .HasColumnName("createdAt")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.Property(c => c.UpdatedAt).HasColumnName("updatedAt");
    }
}
