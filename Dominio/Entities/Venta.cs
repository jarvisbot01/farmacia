namespace Dominio.Entities;

public class Venta : BaseEntity
{
    public int IdClienteFk { get; set; }
    public Cliente? Cliente { get; set; }
    public int IdEmpleadoFk { get; set; }
    public Empleado? Empleado { get; set; }

    ICollection<DetalleVenta>? DetalleVentas { get; set; }
}
