using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;

namespace Application.Repository;

public class CompraRepository : GenericRepository<Compra>, ICompra
{
    private readonly FarmaciaContext _context;

    public CompraRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }
}
