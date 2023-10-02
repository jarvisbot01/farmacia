using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly FarmaciaContext _context;

    public MedicamentoRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos
            .Include(m => m.DetalleVentas)
            .Include(m => m.Lotes)
            .AsSplitQuery()
            .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(int id)
    {
        return await _context.Medicamentos
            .Include(m => m.DetalleVentas)
            .Include(m => m.Lotes)
            .AsSplitQuery()
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Medicamento>> GetMedicamentosConMenosDe50Unidades(int cantidad)
    {
        // Obtener la consulta como IQueryable
        var query = _context.Medicamentos
            .Where(m => Convert.ToInt32(m.Stock) < 51)
            .OrderByDescending(m => m.Id)
            .Take(cantidad);

        // Finalmente, convierte la consulta a una lista asíncrona
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Medicamento>> GetMedicamentosPorProveedor(string nombreProveedor)
    {
        return await _context.Compras
            .Include(c => c.Proveedor)
            .Include(c => c.Lotes)
            .ThenInclude(l => l.Medicamento)
            .Where(c => c.Proveedor.Nombre == nombreProveedor)
            .SelectMany(c => c.Lotes.Select(l => l.Medicamento))
            .Distinct()
            .ToListAsync();
    }

    public async Task<int> GetTotalVentasPorMedicamento(string nombreMedicamento)
    {
        return await _context.DetalleVentas
            .Include(dv => dv.Medicamento)
            .Where(dv => dv.Medicamento.Nombre == nombreMedicamento)
            .SumAsync(dv => dv.Cantidad);
    }

    public async Task<IEnumerable<Medicamento>> GetMedicamentosNoVendidos()
    {
        var result = await _context.Medicamentos
            .Include(m => m.DetalleVentas)
            .Where(m => !m.DetalleVentas.Any())
            .ToListAsync();

        return result;
    }

    public async Task<Medicamento> GetMedicamentoMenosVendidoEn2023()
    {
        var query =
            from dv in _context.DetalleVentas
            join m in _context.Medicamentos on dv.IdMedicamentoFk equals m.Id
            join v in _context.Ventas on dv.IdVentaFk equals v.Id
            where v.CreatedAt.Year == 2023
            group dv by m into g
            orderby g.Sum(dv => dv.Cantidad) ascending
            select g.Key;

        var result = await query.FirstOrDefaultAsync();
        return result;
    }
}
