using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly FarmaciaContext _context;

    public ProveedorRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedores
            .Include(p => p.Compras)
            .ThenInclude(l => l.Lotes)
            .ThenInclude(d => d.DetalleVentas)
            .AsSplitQuery()
            .ToListAsync();
    }

    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Proveedores
            .Include(p => p.Compras)
            .ThenInclude(l => l.Lotes)
            .ThenInclude(d => d.DetalleVentas)
            .AsSplitQuery()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<object>> GetTotalMedicamentosVendidosPorProveedor()
    {
        var result = await _context.Proveedores
            .Include(p => p.Compras)
            .ThenInclude(c => c.Lotes)
            .ThenInclude(l => l.DetalleVentas)
            .Select(
                p =>
                    new
                    {
                        NombreProveedor = p.Nombre,
                        TotalVendido = p.Compras
                            .SelectMany(c => c.Lotes)
                            .SelectMany(l => l.DetalleVentas)
                            .Sum(dv => dv.Cantidad)
                    }
            )
            .ToListAsync();

        return result;
    }
}
