using API.Dtos;

namespace API.Services;

public interface IEmpleadoService
{
    Task<string> RegisterAsync(RegisterDto registerDto);
    Task<DataEmpleadoDto> GetTokenAsync(LoginDto loginDto);
    Task<string> AddRolAsync(AddRolDto addRolDto);
    Task<DataEmpleadoDto> RefreshTokenAsync(string refreshToken);
}
