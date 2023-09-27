using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly FarmaciaContext _context;

    public EmpleadoRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados
            .Include(e => e.Ventas)
            .ThenInclude(d => d.DetalleVentas)
            .AsSplitQuery()
            .ToListAsync();
    }

    public override async Task<Empleado> GetByIdAsync(int id)
    {
        return await _context.Empleados
            .Include(e => e.Ventas)
            .ThenInclude(d => d.DetalleVentas)
            .AsSplitQuery()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Empleado> GetByNombreAsync(string nombre)
    {
        return await _context.Empleados
            .Include(e => e.Roles)
            .Include(e => e.RefreshTokens)
            .AsSplitQuery()
            .FirstOrDefaultAsync(e => e.Nombre.ToLower() == nombre.ToLower());
    }

    public async Task<Empleado> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Empleados
            .Include(e => e.Roles)
            .Include(e => e.RefreshTokens)
            .AsSplitQuery()
            .FirstOrDefaultAsync(e => e.RefreshTokens.Any(t => t.Token == refreshToken));
    }
}
