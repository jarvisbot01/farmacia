using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class RegisterDto
{
    [Required]
    public int Cedula { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Direccion { get; set; }

    [Required]
    public string Telefono { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Rol { get; set; }
}
