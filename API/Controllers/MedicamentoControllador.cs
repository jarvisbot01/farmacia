using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MedicamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MedicamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get()
    {
        var medicamentos = await _unitOfWork.Medicamentos.GetAllAsync();
        return _mapper.Map<List<MedicamentoDto>>(medicamentos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoDto>> Get(int id)
    {
        var medicamento = await _unitOfWork.Medicamentos.GetByIdAsync(id);
        if (medicamento == null)
        {
            return NotFound();
        }

        return _mapper.Map<MedicamentoDto>(medicamento);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicamentoDto>> Post(MedicamentoDto medicamentoDto)
    {
        var medicamento = _mapper.Map<Medicamento>(medicamentoDto);
        _unitOfWork.Medicamentos.Add(medicamento);
        await _unitOfWork.SaveAsync();

        if (medicamento == null)
        {
            return BadRequest();
        }

        medicamentoDto.Id = medicamento.Id;
        return CreatedAtAction(nameof(Post), new { id = medicamentoDto.Id }, medicamentoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicamentoDto>> Put(
        int id,
        [FromBody] MedicamentoDto medicamentoDto
    )
    {
        var medicamentoToUpdate = await _unitOfWork.Medicamentos.GetByIdAsync(id);
        if (medicamentoToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(medicamentoDto, medicamentoToUpdate);
        _unitOfWork.Medicamentos.Update(medicamentoToUpdate);
        await _unitOfWork.SaveAsync();
        return medicamentoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var medicamento = await _unitOfWork.Medicamentos.GetByIdAsync(id);
        if (medicamento == null)
        {
            return NotFound();
        }

        _unitOfWork.Medicamentos.Remove(medicamento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("consultaMedicamentosBajoStock")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetMedicamentosBajoStock()
    {
        var medicamentos = await _unitOfWork.Medicamentos.GetMedicamentosConMenosDe50Unidades(50);
        return _mapper.Map<List<MedicamentoDto>>(medicamentos);
    }

    [HttpGet("consultaPorProveedor/{nombreProveedor}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetMedicamentosPorProveedor(
        string nombreProveedor
    )
    {
        var medicamentos = await _unitOfWork.Medicamentos.GetMedicamentosPorProveedor(
            nombreProveedor
        );
        return _mapper.Map<List<MedicamentoDto>>(medicamentos);
    }

    [HttpGet("totalVentas/{nombreMedicamento}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> GetTotalVentasPorMedicamento(string nombreMedicamento)
    {
        var totalVentas = await _unitOfWork.Medicamentos.GetTotalVentasPorMedicamento(
            nombreMedicamento
        );
        return Ok(totalVentas);
    }

    [HttpGet("medicamentosNoVendidos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> GetMedicamentosNoVendidos()
    {
        var medicamentos = await _unitOfWork.Medicamentos.GetMedicamentosNoVendidos();
        return _mapper.Map<List<MedicamentoDto>>(medicamentos);
    }
}
