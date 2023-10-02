using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IMedicamento : IGeneric<Medicamento>
{
    Task<IEnumerable<Medicamento>> GetMedicamentosConMenosDe50Unidades(int cantidad);
    Task<IEnumerable<Medicamento>> GetMedicamentosPorProveedor(string nombreProveedor);
    Task<int> GetTotalVentasPorMedicamento(string nombreMedicamento);
    Task<IEnumerable<Medicamento>> GetMedicamentosNoVendidos();
    Task<Medicamento> GetMedicamentoMenosVendidoEn2023();
}
