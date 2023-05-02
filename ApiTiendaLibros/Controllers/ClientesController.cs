using ApiTiendaLibros.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTiendaLibros.Controllers;
public class ClientesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClientesListDto>>> Get()
    {
        var cliente = await _unitOfWork.Clientes.GetAllAsync();
        return _mapper.Map<List<ClientesListDto>>(cliente);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);
        return Ok(cliente);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Post(ClienteAddUpdateDto clienteDto)
    {
        var cliente = _mapper.Map<Cliente>(clienteDto);
        _unitOfWork.Clientes.Add(cliente);
        await _unitOfWork.SaveAsync();
        if (cliente == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = clienteDto.Id }, clienteDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cliente>> Put(int id, [FromBody] Cliente cliente)
    {
        if (cliente == null)
            return NotFound();

        _unitOfWork.Clientes.Update(cliente);
        await _unitOfWork.SaveAsync();

        return cliente;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);

        if (cliente == null)
            return NotFound();

        _unitOfWork.Clientes.Remove(cliente);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
