namespace API.Dtos;

public class CompraDto
{
    public int Id { get; set; }
    public int IdProveedorFk { get; set; }
    public DateTime FechaCompra { get; set; }
    public int PrecioTotal { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<LoteDto> Lotes { get; set; }
}
