using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class DetalleVentaRepository : GenericRepository<DetalleVenta>, IDetalleVenta
{
    private readonly FarmaciaContext _context;

    public DetalleVentaRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<decimal> ObtenerTotalRecaudado()
    {
        return await _context.DetalleVentas.SumAsync(dv => dv.Subtotal);
    }
}
