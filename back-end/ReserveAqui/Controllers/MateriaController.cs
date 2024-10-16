using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.DTOs;
using ReserveAqui.Models;
using ReserveAqui.Repositories;

namespace ReserveAqui.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MateriaController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public MateriaController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    [HttpGet("{id:int}", Name = "ObterMateria")]
    public async Task<ActionResult<Materia>> Get(int id)
    {
        var materia = await _uof.Materias.GetMateriaAsync(id);
        if (materia is null)
        {
            return NotFound("Matéria não encontrada.");
        }

        return Ok(materia);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Materia>>> GetAll()
    {
        var materias = await _uof.Materias.GetAllAsync();

        if (materias is null || !materias.Any())
        {
            return NotFound("Não existe matéria cadastrada.");
        }

        return Ok(materias);
    }

    [HttpPost]
    public async Task<ActionResult<Materia>> Create(MateriaDto materiaDto)
    {
        if (materiaDto is null)
        {
            return BadRequest("Dados inválidos");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var materia = new Materia
        {
            Nome = materiaDto.Nome,
        };


        await _uof.Materias.AddAsync(materia);
        await _uof.Complete();
        return new CreatedAtRouteResult("ObterMateria",
            new { id = materia.Id },
            materia);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Materia>> Update(MateriaDto materiaDto, int id)
    {
        var materia = await _uof.Materias.GetMateriaAsync(id);

        if(materia is null)
        {
            return NotFound("Matéria não encotrada");
        }

        if (materiaDto is null)
        {
            return BadRequest("Dados inválidos");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        materia.Nome = materiaDto.Nome;

        await _uof.Materias.UpdateAsync(materia);
        await _uof.Complete();
        return Ok(materia);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Materia>> Remove(int id)
    {
        var materia = await _uof.Materias.GetAsync(id);

        if (materia is null)
        {
            return NotFound("Matéria não encontrada"); 
        }

        await _uof.Materias.RemoveAsync(materia);
        await _uof.Complete();
        return Ok("Matéria removida com sucesso.");
    }


}
