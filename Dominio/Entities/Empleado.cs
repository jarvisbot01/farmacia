namespace Dominio.Entities;

public class Empleado : BaseEntity
{
    public int Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public int RolIdFk { get; set; }
    public Rol Rol { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Venta> Ventas { get; set; }
}
