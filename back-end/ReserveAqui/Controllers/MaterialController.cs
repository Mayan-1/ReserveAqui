using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.DTOs;
using ReserveAqui.Models;
using ReserveAqui.Repositories;

namespace ReserveAqui.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public MaterialController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Material>> Get(int id)
    {
        var material = await _uof.Materiais.GetAsync(id);
        if (material == null)
        {
            return BadRequest("Material não encontrado.");
        }

        return Ok(material);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Material>>> GetAll()
    {
        var materiais = await _uof.Materiais.GetAllAsync();

        if (materiais == null || !materiais.Any())
        {
            return BadRequest("Nenhum material cadastrado.");
        }

        return Ok(materiais);
    }

    [HttpPost]
    public async Task<ActionResult<Material>> Create(MaterialDto materialDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var material = new Material
        {
            Nome = materialDto.Nome,
        };

        await _uof.Materiais.AddAsync(material);
        await _uof.Complete();
        return Ok(material);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Material>> Update(MaterialDto materialDto, int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var material = await _uof.Materiais.GetAsync(id);

        if (material == null)
        {
            return BadRequest("Material não encontrado");
        }

        material.Nome = materialDto.Nome;

        await _uof.Materiais.UpdateAsync(material);
        await _uof.Complete();
        return Ok(material);
    }
}
