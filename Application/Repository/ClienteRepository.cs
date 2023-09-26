using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly FarmaciaContext _context;

    public ClienteRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .Include(c => c.RecetasMedicas)
            .Include(r => r.Ventas)
            .ThenInclude(d => d.DetalleVentas)
            .AsSplitQuery()
            .ToListAsync();
    }

    public override async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
            .Include(c => c.RecetasMedicas)
            .Include(r => r.Ventas)
            .ThenInclude(d => d.DetalleVentas)
            .AsSplitQuery()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
