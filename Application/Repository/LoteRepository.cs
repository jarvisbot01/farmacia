using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class LoteRepository : GenericRepository<Lote>, ILote
{
    private readonly FarmaciaContext _context;

    public LoteRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Lote>> GetAllAsync()
    {
        return await _context.Lotes
            .Include(l => l.DetalleVentas)
            .AsSplitQuery()
            .ToListAsync();
    }

    public override async Task<Lote> GetByIdAsync(int id)
    {
        return await _context.Lotes
            .Include(l => l.DetalleVentas)
            .AsSplitQuery()
            .FirstOrDefaultAsync(l => l.Id == id);
    }
}
