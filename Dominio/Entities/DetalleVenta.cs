namespace Dominio.Entities;

public class DetalleVenta : BaseEntity
{
    public int IdVentaFk { get; set; }
    public Venta? Venta { get; set; }
    public int IdMedicamentoFk { get; set; }
    public Medicamento? Medicamento { get; set; }
    public int IdLoteFk { get; set; }
    public Lote? Lote { get; set; }
    public int Cantidad { get; set; }
    public int PrecioUnitario { get; set; }
    public int Subtotal { get; set; }
    public DateTime UpdatedAt { get; set; }
}
