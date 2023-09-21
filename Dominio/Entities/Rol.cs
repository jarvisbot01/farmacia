namespace Dominio.Entities;

public class Rol : BaseEntity
{
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; } // para que??
    public DateTime UpdatedAt { get; set; }
}
