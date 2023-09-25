using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RecetaMedicaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RecetaMedicaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RecetaMedicaDto>>> Get()
    {
        var recetasMedicas = await _unitOfWork.RecetasMedicas.GetAllAsync();
        return _mapper.Map<List<RecetaMedicaDto>>(recetasMedicas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RecetaMedicaDto>> Get(int id)
    {
        var recetaMedica = await _unitOfWork.RecetasMedicas.GetByIdAsync(id);
        if (recetaMedica == null)
        {
            return NotFound();
        }

        return _mapper.Map<RecetaMedicaDto>(recetaMedica);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RecetaMedicaDto>> Post(RecetaMedicaDto recetaMedicaDto)
    {
        var recetaMedica = _mapper.Map<RecetaMedica>(recetaMedicaDto);
        _unitOfWork.RecetasMedicas.Add(recetaMedica);
        await _unitOfWork.SaveAsync();

        if (recetaMedica == null)
        {
            return BadRequest();
        }

        recetaMedicaDto.Id = recetaMedica.Id;
        return CreatedAtAction(nameof(Post), new { id = recetaMedicaDto.Id }, recetaMedicaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RecetaMedicaDto>> Put(
        int id,
        [FromBody] RecetaMedicaDto recetaMedicaDto
    )
    {
        var recetaMedicaToUpdate = await _unitOfWork.RecetasMedicas.GetByIdAsync(id);
        if (recetaMedicaToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(recetaMedicaDto, recetaMedicaToUpdate);
        _unitOfWork.RecetasMedicas.Update(recetaMedicaToUpdate);
        await _unitOfWork.SaveAsync();
        return recetaMedicaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var recetaMedica = await _unitOfWork.RecetasMedicas.GetByIdAsync(id);
        if (recetaMedica == null)
        {
            return NotFound();
        }

        _unitOfWork.RecetasMedicas.Remove(recetaMedica);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
