using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;

namespace Application.Repository;

public class RecetaMedicaRepository : GenericRepository<RecetaMedica>, IRecetaMedica
{
    private readonly FarmaciaContext _context;

    public RecetaMedicaRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }
}
