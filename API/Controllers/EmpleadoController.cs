using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Services;

namespace API.Controllers;

public class EmpleadoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IEmpleadoService _empleadoService;

    public EmpleadoController(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IEmpleadoService empleadoService
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _empleadoService = empleadoService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        var empleados = await _unitOfWork.Empleados.GetAllAsync();
        return _mapper.Map<List<EmpleadoDto>>(empleados);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDto>> Get(int id)
    {
        var empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
        if (empleado == null)
        {
            return NotFound();
        }

        return _mapper.Map<EmpleadoDto>(empleado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpleadoDto>> Post(EmpleadoDto empleadoDto)
    {
        var empleado = _mapper.Map<Empleado>(empleadoDto);
        _unitOfWork.Empleados.Add(empleado);
        await _unitOfWork.SaveAsync();

        if (empleado == null)
        {
            return BadRequest();
        }

        empleadoDto.Id = empleado.Id;
        return CreatedAtAction(nameof(Post), new { id = empleadoDto.Id }, empleadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody] EmpleadoDto empleadoDto)
    {
        var empleadoToUpdate = await _unitOfWork.Empleados.GetByIdAsync(id);
        if (empleadoToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(empleadoDto, empleadoToUpdate);
        _unitOfWork.Empleados.Update(empleadoToUpdate);
        await _unitOfWork.SaveAsync();
        return empleadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var empleado = await _unitOfWork.Empleados.GetByIdAsync(id);
        if (empleado == null)
        {
            return NotFound();
        }

        _unitOfWork.Empleados.Remove(empleado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync(RegisterDto registerDto)
    {
        var result = await _empleadoService.RegisterAsync(registerDto);
        return Ok(result);
    }

    [HttpPost("token")]
    public async Task<IActionResult> GetTokenAsync(LoginDto loginDto)
    {
        var result = await _empleadoService.GetTokenAsync(loginDto);
        SetRefreshTokenInCookie(result.RefreshToken ?? string.Empty);
        return Ok(result);
    }

    [HttpPost("addrole")]
    public async Task<IActionResult> AddRolAsync(AddRolDto addRolDto)
    {
        var result = await _empleadoService.AddRolAsync(addRolDto);
        return Ok(result);
    }

    [HttpPost("refreshtoken")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized("Empleado no autorizado");
        }

        var response = await _empleadoService.RefreshTokenAsync(refreshToken);
        if (!string.IsNullOrEmpty(response.RefreshToken))
            SetRefreshTokenInCookie(response.RefreshToken);

        return Ok(response);
    }

    private void SetRefreshTokenInCookie(string refreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(1),
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
    }
}
