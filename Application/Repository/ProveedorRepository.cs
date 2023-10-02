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

    public async Task<IEnumerable<object>> GetProveedoresConMedicamentos()
    {
        var datos = await (
            from p in _context.Proveedores
            join c in _context.Compras on p.Id equals c.IdProveedorFk
            join l in _context.Lotes on c.Id equals l.IdCompraFk
            join m in _context.Medicamentos on l.IdMedicamentoFk equals m.Id
            select new
            {
                NombreProveedor = p.Nombre,
                p.Direccion,
                p.Telefono,
                p.Email,
                NombreMedicamento = m.Nombre
            }
        ).ToListAsync();

        var resultado = datos
            .GroupBy(
                d =>
                    new
                    {
                        d.NombreProveedor,
                        d.Direccion,
                        d.Telefono,
                        d.Email
                    }
            )
            .Select(
                g =>
                    new
                    {
                        NombreProveedor = g.Key.NombreProveedor,
                        Direccion = g.Key.Direccion,
                        Telefono = g.Key.Telefono,
                        Email = g.Key.Email,
                        Medicamentos = g.Select(d => d.NombreMedicamento).Distinct().ToList()
                    }
            );

        return resultado;
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

    public async Task<IEnumerable<object>> GetNumeroDeMedicamentosPorProveedor()
    {
        var query =
            from p in _context.Proveedores
            join c in _context.Compras on p.Id equals c.IdProveedorFk
            join l in _context.Lotes on c.Id equals l.IdCompraFk
            join m in _context.Medicamentos on l.IdMedicamentoFk equals m.Id
            group m by p.Nombre into g
            select new
            {
                NombreProveedor = g.Key,
                NumeroDeMedicamentos = g.Select(m => m.Id).Distinct().Count()
            };

        var result = await query.ToListAsync();
        return result;
    }
}
