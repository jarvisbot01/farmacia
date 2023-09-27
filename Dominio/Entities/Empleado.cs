namespace Dominio.Entities;

public class Empleado : BaseEntity
{
    public int Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Venta> Ventas { get; set; }
    public ICollection<EmpleadoRol> EmpleadoRoles { get; set; }
    public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
}
