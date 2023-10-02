using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProveedorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
    {
        var proveedores = await _unitOfWork.Proveedores.GetAllAsync();
        return _mapper.Map<List<ProveedorDto>>(proveedores);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProveedorDto>> Get(int id)
    {
        var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if (proveedor == null)
        {
            return NotFound();
        }

        return _mapper.Map<ProveedorDto>(proveedor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProveedorDto>> Post(ProveedorDto proveedorDto)
    {
        var proveedor = _mapper.Map<Proveedor>(proveedorDto);
        _unitOfWork.Proveedores.Add(proveedor);
        await _unitOfWork.SaveAsync();

        if (proveedor == null)
        {
            return BadRequest();
        }

        proveedorDto.Id = proveedor.Id;
        return CreatedAtAction(nameof(Post), new { id = proveedorDto.Id }, proveedorDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody] ProveedorDto proveedorDto)
    {
        var proveedorToUpdate = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if (proveedorToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(proveedorDto, proveedorToUpdate);
        _unitOfWork.Proveedores.Update(proveedorToUpdate);
        await _unitOfWork.SaveAsync();
        return proveedorDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);
        if (proveedor == null)
        {
            return NotFound();
        }

        _unitOfWork.Proveedores.Remove(proveedor);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("proveedores-medicamentos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> GetProveedoresConMedicamentos()
    {
        var proveedores = await _unitOfWork.Proveedores.GetProveedoresConMedicamentos();
        return Ok(proveedores);
    }

    [HttpGet("totalMedicamentosVendidos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> GetTotalMedicamentosVendidosPorProveedor()
    {
        var resultado = await _unitOfWork.Proveedores.GetTotalMedicamentosVendidosPorProveedor();
        return Ok(resultado);
    }

    [HttpGet("numeroDeMedicamentos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> GetNumeroDeMedicamentosPorProveedor()
    {
        var resultado = await _unitOfWork.Proveedores.GetNumeroDeMedicamentosPorProveedor();
        return Ok(resultado);
    }
}
