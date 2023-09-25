namespace API.Dtos;

public class EmpleadoDto
{
    public int Id { get; set; }
    public int IdRolFk { get; set; }
    public int Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<VentaDto> Ventas { get; set; }
}
