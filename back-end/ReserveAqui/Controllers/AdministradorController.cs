using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.DTOs;
using ReserveAqui.Models;
using ReserveAqui.Repositories;

namespace ReserveAqui.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdministradorController : ControllerBase
{
    private readonly IUnitOfWork _uof;
    private readonly ILogger<AdministradorController> _logger;

    public AdministradorController(IUnitOfWork uof, ILogger<AdministradorController> logger)
    {
        _uof = uof;
        _logger = logger;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Administrador>> Get(int id)
    {
        _logger.LogInformation($"Get-AdministradorController - {DateTime.Now}");
        var administrador = await _uof.Administradores.GetAsync(id);
        if(administrador == null)
        {
            return NotFound("Administrador não encontrado.");
        }

        return Ok(administrador);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Administrador>>> GetAll()
    {
        var administradores = await _uof.Administradores.GetAllAsync();

        if(administradores == null || !administradores.Any())
        {
            return NotFound("Nenhum administrador cadastrado.");
        }

        return Ok(administradores);
    }

    [HttpPost("{idInstituicao:int}")]
    public async Task<ActionResult<Administrador>> Create(AdministradorDto administradorDto, int idInstituicao)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var instituicao = await _uof.Instituicoes.GetInstituicaoAsync(idInstituicao);

        if(instituicao == null)
        {
            return NotFound("Nenhuma instituição encontrada");
        }

        var administrador = new Administrador
        {
            Nome = administradorDto.Nome,
            Cpf = administradorDto.Cpf,
            Email = administradorDto.Email,
            Senha = administradorDto.Senha,
            Telefone = administradorDto.Telefone,
            Instituicao = instituicao,
        };

        await _uof.Administradores.AddAsync(administrador);
        await _uof.Complete();
        return Ok(administrador);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Administrador>> Update(AdministradorDto administradorDto, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var administrador = await _uof.Administradores.GetAdministradorAsync(id);

        if(administrador == null)
        {
            return NotFound("Administrador não encontrado.");
        }

        administrador.Nome = administradorDto.Nome;
        administrador.Email = administradorDto.Email;
        administrador.Senha = administradorDto.Senha;
        administrador.Cpf = administradorDto.Cpf;
        administrador.Telefone = administradorDto.Telefone;

        await _uof.Administradores.UpdateAsync(administrador);
        await _uof.Complete();
        return Ok(administrador);
    }
}
