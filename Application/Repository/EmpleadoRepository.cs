using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly FarmaciaContext _context;

    public EmpleadoRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }
}
