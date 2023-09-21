namespace Dominio.Entities;

public class Lote : BaseEntity
{
    public int IdMedicamentoFk { get; set; }
    public Medicamento? Medicamento { get; set; }
    public int IdCompraFk { get; set; }
    public Compra? Compra { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public int Cantidad { get; set; }
    public int PrecioUnitario { get; set; }
    public int PrecioCompra { get; set; } // Cantidad * PrecioUnitario?
    public DateTime UpdatedAt { get; set; }
}
