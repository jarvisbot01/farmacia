using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;

namespace Application.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly FarmaciaContext _context;

    public ProveedorRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }
}
