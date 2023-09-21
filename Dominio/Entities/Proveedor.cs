namespace Dominio.Entities;

public class Proveedor : BaseEntity
{
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Estado { get; set; }
    public DateTime UpdatedAt { get; set; }
}
