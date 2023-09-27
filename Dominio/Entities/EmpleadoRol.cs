namespace Dominio.Entities;

public class EmpleadoRol
{
    public int IdEmpleadoFk { get; set; }
    public Empleado Empleado { get; set; }
    public int IdRolFk { get; set; }
    public Rol Rol { get; set; }
}
