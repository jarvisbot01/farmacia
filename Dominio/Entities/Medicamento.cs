namespace Dominio.Entities;

public class Medicamento : BaseEntity
{
    public string? Nombre { get; set; }
    public string? Concentracion { get; set; }
    public string? Precio { get; set; }
    public string? Stock { get; set; }
    public string? PrincipioActivo { get; set; } // para que??
    public string? Contraindicaciones { get; set; } // para que??
    public string? DosisRecomendada { get; set; } // para que??
    public DateTime FechaExpedicion { get; set; } // para que??
}
