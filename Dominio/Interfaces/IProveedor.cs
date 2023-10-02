using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IProveedor : IGeneric<Proveedor>
{
    Task<IEnumerable<object>> GetProveedoresConMedicamentos();
    Task<IEnumerable<object>> GetTotalMedicamentosVendidosPorProveedor();
    Task<IEnumerable<object>> GetNumeroDeMedicamentosPorProveedor();
}
