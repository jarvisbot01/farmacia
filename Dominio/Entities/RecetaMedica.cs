namespace Dominio.Entities;

public class RecetaMedica : BaseEntity
{
    public int IdClienteFk { get; set; }
    public Cliente? Cliente { get; set; }
    public string? Token { get; set; }
    public string? Detalle { get; set; }
    public DateTime FechaEmision { get; set; }
}
