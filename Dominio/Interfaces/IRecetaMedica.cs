using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IRecetaMedica : IGeneric<RecetaMedica>
{
    Task<IEnumerable<RecetaMedica>> ObtenerRecetasPosteriorA(DateTime fecha);
}
