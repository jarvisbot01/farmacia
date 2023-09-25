using Persistencia;
using Dominio.Interfaces;
using Application.Repository;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly FarmaciaContext _context;
    private ClienteRepository _clienteRepository;
    private CompraRepository _compraRepository;
    private DetalleVentaRepository _detalleVentaRepository;
    private EmpleadoRepository _empleadoRepository;
    private LoteRepository _loteRepository;
    private MedicamentoRepository _medicamentoRepository;
    private ProveedorRepository _proveedorRepository;
    private RecetaMedicaRepository _recetaMedicaRepository;
    private RolRepository _rolRepository;
    private VentaRepository _ventaRepository;

    public UnitOfWork(FarmaciaContext context)
    {
        _context = context;
    }

    public ICliente Clientes => _clienteRepository ??= new ClienteRepository(_context);

    public ICompra Compras => _compraRepository ??= new CompraRepository(_context);

    public IDetalleVenta DetallesVentas =>
        _detalleVentaRepository ??= new DetalleVentaRepository(_context);

    public IEmpleado Empleados => _empleadoRepository ??= new EmpleadoRepository(_context);

    public ILote Lotes => _loteRepository ??= new LoteRepository(_context);

    public IMedicamento Medicamentos =>
        _medicamentoRepository ??= new MedicamentoRepository(_context);

    public IProveedor Proveedores => _proveedorRepository ??= new ProveedorRepository(_context);

    public IRecetaMedica RecetasMedicas =>
        _recetaMedicaRepository ??= new RecetaMedicaRepository(_context);

    public IRol Roles => _rolRepository ??= new RolRepository(_context);

    public IVenta Ventas => _ventaRepository ??= new VentaRepository(_context);

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
