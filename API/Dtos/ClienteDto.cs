namespace API.Dtos;

public class ClienteDto
{
    public int Id { get; set; }
    public int Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public bool EstaRegistrado { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<RecetaMedicaDto> RecetasMedicas { get; set; }
    public List<VentaDto> Ventas { get; set; }
}
