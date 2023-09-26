using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class VentaRepository : GenericRepository<Venta>, IVenta
{
    private readonly FarmaciaContext _context;

    public VentaRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Venta>> GetAllAsync()
    {
        return await _context.Ventas.Include(x => x.DetalleVentas).ToListAsync();
    }

    public override async Task<Venta> GetByIdAsync(int id)
    {
        return await _context.Ventas
            .Include(x => x.DetalleVentas)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
