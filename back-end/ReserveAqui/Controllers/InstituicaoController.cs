using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.DTOs;
using ReserveAqui.Models;
using ReserveAqui.Repositories;

namespace ReserveAqui.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public InstituicaoController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    [HttpGet("{id:int}", Name = "ObterInstituicao")]
    public async Task<ActionResult<Instituicao>> Get(int id)
    {
        var instituicao = await _uof.Instituicoes.GetAsync(id);
        if (instituicao == null)
        {
            return NotFound($"Instituição não encontrada.");
        }

        return Ok(instituicao);
    }

    [HttpGet(Name = "ObterInstituicoes")]
    public async Task<ActionResult<IEnumerable<Instituicao>>> GetAll()
    {
        var instituicoes = await _uof.Instituicoes.GetAllAsync();
        
        if(instituicoes == null || !instituicoes.Any())
        {
            return NotFound("Não existe instituição cadastrada.");
        }

        return Ok(instituicoes);
    }

    [HttpPost]
    public async Task<ActionResult<Instituicao>> Create(InstituicaoDto instituicaoDto)
    {
        if(instituicaoDto is null)
        {
            return BadRequest("Dados inválidos");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var instituicao = new Instituicao
        {
            Nome = instituicaoDto.Nome,
        };

        await _uof.Instituicoes.AddAsync(instituicao);
        await _uof.Complete();

        return new CreatedAtRouteResult("ObterInstituicao",
            new { id = instituicao.Id },
            instituicao);

    }

    [HttpPut]
    public async Task<ActionResult<Instituicao>> Update(Instituicao instituicao)
    {
        if (instituicao is null)
        {
            return BadRequest("Dados inválidos");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _uof.Instituicoes.UpdateAsync(instituicao);
        await _uof.Complete();

        return Ok(instituicao);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<IEnumerable<Instituicao>>> Remove(int id)
    {
        var instituicao = await _uof.Instituicoes.GetAsync(id);
        if(instituicao is null)
        {
            return NotFound("Instituição não encontrada.");
        }

        await _uof.Instituicoes.RemoveAsync(instituicao);
        await _uof.Complete();

        return Ok("Instituição removida com sucesso.");
    }

    
}
