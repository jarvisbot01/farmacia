using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly FarmaciaContext _context;

    public RolRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }
}
