using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;

namespace Application.Repository;

public class VentaRepository : GenericRepository<Venta>, IVenta
{
    private readonly FarmaciaContext _context;

    public VentaRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }
}
