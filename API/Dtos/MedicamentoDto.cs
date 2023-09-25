namespace API.Dtos;

public class MedicamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Concentracion { get; set; }
    public string Precio { get; set; }
    public string Stock { get; set; }
    public string Contraindicaciones { get; set; }
    public string DosisRecomendada { get; set; }
    public DateTime FechaExpedicion { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<DetalleVentaDto> DetalleVentas { get; set; }
    public List<LoteDto> Lotes { get; set; }
}
