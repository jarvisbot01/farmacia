using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RecetaMedicaRepository : GenericRepository<RecetaMedica>, IRecetaMedica
{
    private readonly FarmaciaContext _context;

    public RecetaMedicaRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RecetaMedica>> ObtenerRecetasPosteriorA(DateTime fecha)
    {
        var fechaDateOnly = DateOnly.FromDateTime(fecha);
        return await _context.RecetasMedicas
            .Where(r => r.FechaEmision > fechaDateOnly)
            .Include(r => r.Cliente)
            .ToListAsync();
    }
}
