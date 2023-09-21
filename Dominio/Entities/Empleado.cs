namespace Dominio.Entities;

public class Empleado : BaseEntity
{
    public int Cedula { get; set; }
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public DateOnly FechaContrato { get; set; } // Para que??
    public int RolIdFk { get; set; }
    public Rol? Rol { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Salario { get; set; } // Para que??
}
