using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IEmpleado : IGeneric<Empleado>
{
    Task<Empleado> GetByNombreAsync(string nombre);
    Task<Empleado> GetByRefreshTokenAsync(string refreshToken);
}
