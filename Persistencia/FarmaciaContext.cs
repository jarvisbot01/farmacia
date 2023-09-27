using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class FarmaciaContext : DbContext
{
    public FarmaciaContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<DetalleVenta> DetalleVentas { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Lote> Lotes { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<RecetaMedica> RecetasMedicas { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<EmpleadoRol> EmpleadoRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
