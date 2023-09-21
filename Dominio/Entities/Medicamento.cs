namespace Dominio.Entities;

public class Medicamento : BaseEntity
{
    public string Nombre { get; set; }
    public string Concentracion { get; set; }
    public string Precio { get; set; }
    public string Stock { get; set; }
    public string Contraindicaciones { get; set; }
    public string DosisRecomendada { get; set; }
    public DateTime FechaExpedicion { get; set; }

    public ICollection<DetalleVenta> DetalleVentas { get; set; }
    public ICollection<Lote> Lotes { get; set; }
}
