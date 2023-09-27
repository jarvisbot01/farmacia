namespace Dominio.Entities;

public class RefreshToken : BaseEntity
{
    public int IdEmpleadoFk { get; set; }
    public Empleado Empleado { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expires;
    public bool IsActive => Revoked == null && !IsExpired;
}
