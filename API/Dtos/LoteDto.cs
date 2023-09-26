namespace API.Dtos;

public class LoteDto
{
    public int Id { get; set; }
    public int IdMedicamentoFk { get; set; }
    public int IdCompraFk { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public int Cantidad { get; set; }
    public int PrecioUnitario { get; set; }
    public int PrecioCompra { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<DetalleVentaDto> DetalleVentas { get; set; }
}
