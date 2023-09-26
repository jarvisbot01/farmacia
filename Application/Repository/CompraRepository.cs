using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class CompraRepository : GenericRepository<Compra>, ICompra
{
    private readonly FarmaciaContext _context;

    public CompraRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Compra>> GetAllAsync()
    {
        return await _context.Compras
            .Include(c => c.Lotes)
            .ThenInclude(l => l.DetalleVentas)
            .AsSplitQuery()
            .ToListAsync();
    }

    public override async Task<Compra> GetByIdAsync(int id)
    {
        return await _context.Compras
            .Include(c => c.Lotes)
            .ThenInclude(l => l.DetalleVentas)
            .AsSplitQuery()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
