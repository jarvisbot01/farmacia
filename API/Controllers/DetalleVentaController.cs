using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class DetalleVentaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DetalleVentaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleVentaDto>>> Get()
    {
        var detalleVentas = await _unitOfWork.DetallesVentas.GetAllAsync();
        return _mapper.Map<List<DetalleVentaDto>>(detalleVentas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleVentaDto>> Get(int id)
    {
        var detalleVenta = await _unitOfWork.DetallesVentas.GetByIdAsync(id);
        if (detalleVenta == null)
        {
            return NotFound();
        }

        return _mapper.Map<DetalleVentaDto>(detalleVenta);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleVentaDto>> Post(DetalleVentaDto detalleVentaDto)
    {
        var detalleVenta = _mapper.Map<DetalleVenta>(detalleVentaDto);
        _unitOfWork.DetallesVentas.Add(detalleVenta);
        await _unitOfWork.SaveAsync();

        if (detalleVenta == null)
        {
            return BadRequest();
        }

        detalleVentaDto.Id = detalleVenta.Id;
        return CreatedAtAction(nameof(Post), new { id = detalleVentaDto.Id }, detalleVentaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleVentaDto>> Put(
        int id,
        [FromBody] DetalleVentaDto detalleVentaDto
    )
    {
        var detalleVentaToUpdate = await _unitOfWork.DetallesVentas.GetByIdAsync(id);
        if (detalleVentaToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(detalleVentaDto, detalleVentaToUpdate);
        _unitOfWork.DetallesVentas.Update(detalleVentaToUpdate);
        await _unitOfWork.SaveAsync();
        return detalleVentaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var detalleVenta = await _unitOfWork.DetallesVentas.GetByIdAsync(id);
        if (detalleVenta == null)
        {
            return NotFound();
        }

        _unitOfWork.DetallesVentas.Remove(detalleVenta);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("total-recaudado")]
    public async Task<IActionResult> GetTotalRecaudado()
    {
        var totalRecaudado = await _unitOfWork.DetallesVentas.ObtenerTotalRecaudado();
        return Ok(totalRecaudado);
    }
}
