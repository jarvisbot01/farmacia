using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IDetalleVenta : IGeneric<DetalleVenta>
{
    Task<decimal> ObtenerTotalRecaudado();
}
