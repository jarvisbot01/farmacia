using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;

namespace Application.Repository;

public class DetalleVentaRepository : GenericRepository<DetalleVenta>, IDetalleVenta
{
    private readonly FarmaciaContext _context;

    public DetalleVentaRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }
}
