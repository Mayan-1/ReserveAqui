using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Models;
using ReserveAqui.Repositories;

namespace ReserveAqui.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdministradorController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public AdministradorController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Administrador>> Get(int id)
    {
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
}
