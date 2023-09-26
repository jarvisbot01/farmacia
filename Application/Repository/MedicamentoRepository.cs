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
}
