namespace Dominio.Entities;

public class Compra : BaseEntity
{
    public int IdProveedorFk { get; set; }
    public Proveedor? Proveedor { get; set; }
    public DateTime FechaCompra { get; set; }
    public int PrecioTotal { get; set; }
    public DateTime UpdatedAt { get; set; } // Para que??
}
