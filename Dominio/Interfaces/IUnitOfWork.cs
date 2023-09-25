namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    ICliente Clientes { get; }
    ICompra Compras { get; }
    IDetalleVenta DetallesVentas { get; }
    IEmpleado Empleados { get; }
    ILote Lotes { get; }
    IMedicamento Medicamentos { get; }
    IProveedor Proveedores { get; }
    IRecetaMedica RecetasMedicas { get; }
    IRol Roles { get; }
    IVenta Ventas { get; }

    Task<int> SaveAsync();
}
