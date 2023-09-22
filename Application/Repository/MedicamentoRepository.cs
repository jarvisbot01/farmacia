using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;

namespace Application.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly FarmaciaContext _context;

    public MedicamentoRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }
}
