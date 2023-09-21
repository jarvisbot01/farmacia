using System.Reflection;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class FarmaciaContext : DbContext
{
    public FarmaciaContext(DbContextOptions options)
        : base(options) { }
    public DbSet<Cliente> Clientes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FarmaciaContext).Assembly);
    }
}
