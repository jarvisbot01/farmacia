namespace API.Dtos;

public class DetalleVentaDto
{
    public int Id { get; set; }
    public int IdVentaFk { get; set; }
    public int IdMedicamentoFk { get; set; }
    public int IdLoteFk { get; set; }
    public int Cantidad { get; set; }
    public int PrecioUnitario { get; set; }
    public int SubTotal { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
