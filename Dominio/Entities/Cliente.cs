namespace Dominio.Entities;

public class Cliente : BaseEntity
{
    public int Cedula { get; set; }
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public bool EstaRegistrado { get; set; }
    public DateTime UpdatedAt { get; set; }

    ICollection<RecetaMedica>? RecetasMedicas { get; set; }
    ICollection<Venta>? Ventas { get; set; }
}
