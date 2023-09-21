namespace Dominio.Entities;

public class Rol : BaseEntity
{
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime UpdatedAt { get; set; }

    ICollection<Empleado>? Empleados { get; set; }
}
