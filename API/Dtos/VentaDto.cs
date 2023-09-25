namespace API.Dtos;

public class VentaDto
{
    public int Id { get; set; }
    public int IdClienteFk { get; set; }
    public int IdEmpleadoFk { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<DetalleVentaDto> DetalleVentas { get; set; }
}
