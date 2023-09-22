using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;

namespace Application.Repository;

public class LoteRepository : GenericRepository<Lote>, ILote
{
    private readonly FarmaciaContext _context;

    public LoteRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }
}
