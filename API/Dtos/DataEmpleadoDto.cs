using System.Text.Json.Serialization;

namespace API.Dtos;

public class DataEmpleadoDto
{
    public string Message { get; set; }
    public bool IsAuthenticated { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
    public string Token { get; set; }

    [JsonIgnore]
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpriration { get; set; }
}
