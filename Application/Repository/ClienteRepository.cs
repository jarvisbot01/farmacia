using Persistencia;
using Dominio.Entities;
using Dominio.Interfaces;

namespace Application.Repository;

public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly FarmaciaContext _context;

    public ClienteRepository(FarmaciaContext context)
        : base(context)
    {
        _context = context;
    }
}
