using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class LoteController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LoteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LoteDto>>> Get()
    {
        var lotes = await _unitOfWork.Lotes.GetAllAsync();
        return _mapper.Map<List<LoteDto>>(lotes);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LoteDto>> Get(int id)
    {
        var lote = await _unitOfWork.Lotes.GetByIdAsync(id);
        if (lote == null)
        {
            return NotFound();
        }

        return _mapper.Map<LoteDto>(lote);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoteDto>> Post(LoteDto loteDto)
    {
        var lote = _mapper.Map<Lote>(loteDto);
        _unitOfWork.Lotes.Add(lote);
        await _unitOfWork.SaveAsync();

        if (lote == null)
        {
            return BadRequest();
        }

        loteDto.Id = lote.Id;
        return CreatedAtAction(nameof(Post), new { id = loteDto.Id }, loteDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LoteDto>> Put(int id, [FromBody] LoteDto loteDto)
    {
        var loteToUpdate = await _unitOfWork.Lotes.GetByIdAsync(id);
        if (loteToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(loteDto, loteToUpdate);
        _unitOfWork.Lotes.Update(loteToUpdate);
        await _unitOfWork.SaveAsync();
        return loteDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var lote = await _unitOfWork.Lotes.GetByIdAsync(id);
        if (lote == null)
        {
            return NotFound();
        }

        _unitOfWork.Lotes.Remove(lote);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
