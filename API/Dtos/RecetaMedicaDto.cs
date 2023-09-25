namespace API.Dtos;

public class RecetaMedicaDto
{
    public int Id { get; set; }
    public int IdClienteFk { get; set; }
    public string Token { get; set; }
    public string Detalle { get; set; }
    public DateOnly FechaEmision { get; set; }
    public DateTime CreatedAt { get; set; }
}
