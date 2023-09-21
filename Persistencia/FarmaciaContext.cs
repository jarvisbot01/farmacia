using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class FarmaciaContext : DbContext
{
    public FarmaciaContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FarmaciaContext).Assembly);
    }
}
