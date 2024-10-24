using Microsoft.AspNetCore.Mvc;
using ReserveAqui.DTOs;
using ReserveAqui.Models;
using ReserveAqui.Repositories;

namespace ReserveAqui.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalaController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public SalaController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Sala>> Get(int id)
    {
        var sala = await _uof.Salas.GetAsync(id);

        if (sala == null)
        {
            return BadRequest("Sala não encontrada");
        }

        return Ok(sala);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sala>>> GetAll()
    {
        var salas = await _uof.Salas.GetAllAsync();

        if (salas == null || !salas.Any())
        {
            return BadRequest("Nenhuma sala cadastrada.");
        }
        
        return Ok(salas);
    }

    [HttpPost]
    public async Task<ActionResult<Sala>> Create(SalaDto salaDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var sala = new Sala
        {
            Nome = salaDto.Nome,
        };

        await _uof.Salas.AddAsync(sala);
        await _uof.Complete();
        return Ok(sala);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Sala>> Update(SalaDto salaDto, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var sala = await _uof.Salas.GetAsync(id);
        if(sala == null)
        {
            return BadRequest("Sala não encontrada");
        }

        sala.Nome = salaDto.Nome;

        await _uof.Salas.UpdateAsync(sala);
        await _uof.Complete();
        return Ok(sala);
    }
}
