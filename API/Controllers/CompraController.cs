using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CompraController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CompraController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CompraDto>>> Get()
    {
        var compras = await _unitOfWork.Compras.GetAllAsync();
        return _mapper.Map<List<CompraDto>>(compras);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CompraDto>> Get(int id)
    {
        var compra = await _unitOfWork.Compras.GetByIdAsync(id);
        if (compra == null)
        {
            return NotFound();
        }

        return _mapper.Map<CompraDto>(compra);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CompraDto>> Post(CompraDto compraDto)
    {
        var compra = _mapper.Map<Compra>(compraDto);
        _unitOfWork.Compras.Add(compra);
        await _unitOfWork.SaveAsync();

        if (compra == null)
        {
            return BadRequest();
        }

        compraDto.Id = compra.Id;
        return CreatedAtAction(nameof(Post), new { id = compraDto.Id }, compraDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CompraDto>> Put(int id, [FromBody] CompraDto compraDto)
    {
        var compraToUpdate = await _unitOfWork.Compras.GetByIdAsync(id);
        if (compraToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(compraDto, compraToUpdate);
        _unitOfWork.Compras.Update(compraToUpdate);
        await _unitOfWork.SaveAsync();
        return compraDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var compra = await _unitOfWork.Compras.GetByIdAsync(id);
        if (compra == null)
        {
            return NotFound();
        }

        _unitOfWork.Compras.Remove(compra);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
