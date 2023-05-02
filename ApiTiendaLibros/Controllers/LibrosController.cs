using ApiTiendaLibros.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTiendaLibros.Controllers;

public class LibrosController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LibrosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LibrosListDto>>> Get()
    {
        var libro = await _unitOfWork.Libros.GetAllAsync();
        return _mapper.Map<List<LibrosListDto>>(libro);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LibroDto>> Get(int id)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(id);

        if(libro == null) { return NotFound(); }
        return _mapper.Map<LibroDto>(libro);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Libro>> Post(LibroAddUpdateDto libroDto)
    {
        var libro = _mapper.Map<Libro>(libroDto);
        _unitOfWork.Libros.Add(libro);
        await _unitOfWork.SaveAsync();
        if (libro == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = libroDto.Id }, libroDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LibroAddUpdateDto>> Put(int id, [FromBody] LibroAddUpdateDto libroDto)
    {
        if (libroDto == null)
            return NotFound();

        var libro = _mapper.Map<Libro>(libroDto);
        _unitOfWork.Libros.Update(libro);
        await _unitOfWork.SaveAsync();

        return libroDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var libro = await _unitOfWork.Libros.GetByIdAsync(id);

        if (libro == null)
            return NotFound();

        _unitOfWork.Libros.Remove(libro);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
