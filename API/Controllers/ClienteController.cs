using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

public class ClienteController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Vendedor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
    {
        var clientes = await _unitOfWork.Clientes.GetAllAsync();
        return _mapper.Map<List<ClienteDto>>(clientes);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Vendedor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDto>> Get(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        return _mapper.Map<ClienteDto>(cliente);
    }

    [HttpPost]
    [Authorize(Roles = "Vendedor")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Post(ClienteDto clienteDto)
    {
        var cliente = _mapper.Map<Cliente>(clienteDto);
        _unitOfWork.Clientes.Add(cliente);
        await _unitOfWork.SaveAsync();

        if (cliente == null)
        {
            return BadRequest();
        }

        clienteDto.Id = cliente.Id;
        return CreatedAtAction(nameof(Post), new { id = clienteDto.Id }, clienteDto);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Vendedor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody] ClienteDto clienteDto)
    {
        var clienteToUpdate = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (clienteToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(clienteDto, clienteToUpdate);
        _unitOfWork.Clientes.Update(clienteToUpdate);
        await _unitOfWork.SaveAsync();
        return clienteDto;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Vendedor")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _unitOfWork.Clientes.Remove(cliente);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
