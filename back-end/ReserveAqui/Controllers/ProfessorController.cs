using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveAqui.DTOs;
using ReserveAqui.Models;
using ReserveAqui.Repositories;

namespace ReserveAqui.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfessorController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public ProfessorController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    [HttpGet("{id:int}", Name = "ObterProfessor")]
    public async Task<ActionResult<Professor>> Get(int id)
    {
        var professor = await _uof.Professores.GetAsync(id);

        if (professor is null)
        {
            return NotFound("Professor não encontrado.");
        }

        return Ok(professor);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Professor>>> GetAll()
    {
        var professores = await _uof.Professores.GetAllAsync();


        if (professores is null || !professores.Any())
        {
            return NotFound("Não existe professor cadastrado.");
        }

        return Ok(professores);
    }

    [HttpPut("{id:int}, {idInstituicao:int}")]
    public async Task<ActionResult<Instituicao>> Update(ProfessorDto professorDto, int id, int idInstituicao)
    {
        var professor = await _uof.Professores.GetAsync(id);
        var instituicao = await _uof.Instituicoes.GetAsync(idInstituicao);

        if (professor is null)
        {
            return NotFound("Professor não encontrado.");
        }

        professor.Nome = professorDto.Nome;
        professor.Cpf = professorDto.Cpf;
        professor.Email = professorDto.Email;
        professor.Senha = professorDto.Senha;
        professor.Telefone = professorDto.Telefone;
        professor.Instituicao = instituicao;

        var materias = await _uof.Materias.GetAllAsync();
        var materiasSelecionadas = materias.Where(c => professorDto.MateriasNomes.Contains(c.Nome)).ToList();

        professor.Materias.Clear();
        foreach (var item in materiasSelecionadas)
        {
            professor.Materias.Add(item);
        }

        await _uof.Professores.UpdateAsync(professor);
        await _uof.Complete();

        return Ok(professor);
    }

    [HttpPost("{idInstituicao:int}")]
    public async Task<ActionResult<Instituicao>> Create(ProfessorDto professorDto, int idInstituicao)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var instituicao = await _uof.Instituicoes.GetAsync(idInstituicao);

        if (instituicao == null)
        {
            return NotFound("Instituição não encontrada");
        }

        var materias = await _uof.Materias.GetAllAsync();
        var materiasSelecionadas = materias
            .Where(c => professorDto.MateriasNomes.Contains(c.Nome))
            .ToList();

        var professor = new Professor
        {
            Nome = professorDto.Nome,
            Cpf = professorDto.Cpf,
            Senha = professorDto.Senha,
            Email = professorDto.Email,
            Telefone = professorDto.Telefone,
            Materias = materiasSelecionadas,
            Instituicao = instituicao,
        };

        await _uof.Professores.AddAsync(professor);
        await _uof.Complete();

        return Ok(professor);
    }

    



}
