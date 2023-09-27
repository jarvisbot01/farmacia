using API.Dtos;
using API.Helpers;
using Dominio.Entities;
using Dominio.Interfaces;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace API.Services;

public class EmpleadoService : IEmpleadoService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<Empleado> _passwordHasher;

    public EmpleadoService(
        IOptions<JWT> jwt,
        IUnitOfWork unitOfWork,
        IPasswordHasher<Empleado> passwordHasher
    )
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var empleado = new Empleado
        {
            Email = registerDto.Email,
            Nombre = registerDto.Nombre,
            Direccion = registerDto.Direccion,
            Telefono = registerDto.Telefono,
            Cedula = registerDto.Cedula
        };

        empleado.Password = _passwordHasher.HashPassword(empleado, registerDto.Password);

        var existingEmpleado = _unitOfWork.Empleados
            .Find(e => e.Nombre.ToLower() == registerDto.Nombre.ToLower())
            .FirstOrDefault();

        if (existingEmpleado == null)
        {
            var rolDefault = _unitOfWork.Roles
                .Find(r => r.Nombre == Authorization.rolDefault.ToString())
                .First();

            try
            {
                empleado.Roles.Add(rolDefault);
                _unitOfWork.Empleados.Add(empleado);
                await _unitOfWork.SaveAsync();

                return $"Empleado {empleado.Nombre} registrado con éxito";
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                return $"Error: {message}";
            }
        }
        else
        {
            return $"El empleado {empleado.Nombre} ya existe";
        }
    }

    public async Task<DataEmpleadoDto> GetTokenAsync(LoginDto loginDto)
    {
        DataEmpleadoDto dataEmpleadoDto = new DataEmpleadoDto();
        var empleado = await _unitOfWork.Empleados.GetByNombreAsync(loginDto.Nombre);

        if (empleado == null)
        {
            dataEmpleadoDto.IsAuthenticated = false;
            dataEmpleadoDto.Message = $"El empleado {loginDto.Nombre} no existe";

            return dataEmpleadoDto;
        }

        var result = _passwordHasher.VerifyHashedPassword(
            empleado,
            empleado.Password,
            loginDto.Password
        );

        if (result == PasswordVerificationResult.Success)
        {
            dataEmpleadoDto.Message =
                $"El empleado {loginDto.Nombre} ha iniciado sesión correctamente";
            dataEmpleadoDto.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(empleado);
            dataEmpleadoDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            dataEmpleadoDto.Email = empleado.Email;
            dataEmpleadoDto.Nombre = empleado.Nombre;
            dataEmpleadoDto.Roles = empleado.Roles.Select(e => e.Nombre).ToList();

            if (empleado.RefreshTokens.Any(a => a.IsActive))
            {
                var activeRefreshToken = empleado.RefreshTokens
                    .Where(a => a.IsActive == true)
                    .FirstOrDefault();
                dataEmpleadoDto.RefreshToken = activeRefreshToken.Token;
                dataEmpleadoDto.RefreshTokenExpriration = activeRefreshToken.Expires;
            }
            else
            {
                var refreshToken = CreateRefreshToken();
                dataEmpleadoDto.RefreshToken = refreshToken.Token;
                dataEmpleadoDto.RefreshTokenExpriration = refreshToken.Expires;
                empleado.RefreshTokens.Add(refreshToken);
                _unitOfWork.Empleados.Update(empleado);
                await _unitOfWork.SaveAsync();
            }

            return dataEmpleadoDto;
        }
        dataEmpleadoDto.IsAuthenticated = false;
        dataEmpleadoDto.Message = $"Credenciales incorrectas para el empleado {loginDto.Nombre}";

        return dataEmpleadoDto;
    }

    public async Task<string> AddRolAsync(AddRolDto addRolDto)
    {
        var empleado = await _unitOfWork.Empleados.GetByNombreAsync(addRolDto.Nombre);

        if (empleado == null)
        {
            return $"El empleado {addRolDto.Nombre} no existe";
        }

        var result = _passwordHasher.VerifyHashedPassword(
            empleado,
            empleado.Password,
            addRolDto.Password
        );

        if (result == PasswordVerificationResult.Success)
        {
            var rolExists = _unitOfWork.Roles
                .Find(r => r.Nombre.ToLower() == addRolDto.Rol.ToLower())
                .FirstOrDefault();

            if (rolExists != null)
            {
                var empleadoHasRol = empleado.Roles.Any(r => r.Id == rolExists.Id);

                if (empleadoHasRol == false)
                {
                    empleado.Roles.Add(rolExists);
                    _unitOfWork.Empleados.Update(empleado);
                    await _unitOfWork.SaveAsync();
                }

                return $"Rol {addRolDto.Rol} agregado al empleado {addRolDto.Nombre} satisfactoriamente";
            }

            return $"El rol {addRolDto.Rol} no encontrado";
        }

        return $"Credenciales incorrectas para el empleado {addRolDto.Nombre}";
    }

    public async Task<DataEmpleadoDto> RefreshTokenAsync(string refreshToken)
    {
        var dataEmpleadoDto = new DataEmpleadoDto();
        var empleado = await _unitOfWork.Empleados.GetByRefreshTokenAsync(refreshToken);

        if (empleado == null)
        {
            dataEmpleadoDto.IsAuthenticated = false;
            dataEmpleadoDto.Message = "Token no asignado a ningún empleado";

            return dataEmpleadoDto;
        }

        var refreshTokenBd = empleado.RefreshTokens.Single(a => a.Token == refreshToken);

        if (!refreshTokenBd.IsActive)
        {
            dataEmpleadoDto.IsAuthenticated = false;
            dataEmpleadoDto.Message = "Token inactivo";

            return dataEmpleadoDto;
        }

        refreshTokenBd.Revoked = DateTime.UtcNow;
        var newRefreshToken = CreateRefreshToken();
        empleado.RefreshTokens.Add(newRefreshToken);
        _unitOfWork.Empleados.Update(empleado);
        await _unitOfWork.SaveAsync();
        dataEmpleadoDto.IsAuthenticated = true;
        JwtSecurityToken jwtSecurityToken = CreateJwtToken(empleado);
        dataEmpleadoDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        dataEmpleadoDto.Message = "Token actualizado";
        dataEmpleadoDto.Nombre = empleado.Nombre;
        dataEmpleadoDto.Email = empleado.Email;
        dataEmpleadoDto.Roles = empleado.Roles.Select(e => e.Nombre).ToList();
        dataEmpleadoDto.RefreshToken = newRefreshToken.Token;
        dataEmpleadoDto.RefreshTokenExpriration = newRefreshToken.Expires;

        return dataEmpleadoDto;
    }

    private RefreshToken CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var generator = RandomNumberGenerator.Create())
        {
            generator.GetBytes(randomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                Expires = DateTime.UtcNow.AddDays(10),
                Created = DateTime.UtcNow
            };
        }
    }

    private JwtSecurityToken CreateJwtToken(Empleado empleado)
    {
        var roles = empleado.Roles;
        var roleClaims = new List<Claim>();

        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.Nombre));
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, empleado.Nombre),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, empleado.Email),
            new Claim("uid", empleado.Id.ToString()),
        }.Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

        var signingCredentials = new SigningCredentials(
            symmetricSecurityKey,
            SecurityAlgorithms.HmacSha256
        );

        var JwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials
        );

        return JwtSecurityToken;
    }
}
