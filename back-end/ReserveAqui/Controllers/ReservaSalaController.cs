using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.DTOs;
using ReserveAqui.Models;
using ReserveAqui.Repositories;

namespace ReserveAqui.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservaSalaController : ControllerBase
{
    private readonly IUnitOfWork _uof;
    private readonly ILogger<ReservaSalaController> _logger;

    public ReservaSalaController(IUnitOfWork uof, ILogger<ReservaSalaController> logger)
    {
        _uof = uof;
        _logger = logger;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ReservaSala>> Get(int id)
    {
        var reserva = await _uof.ReservasSalas.GetAsync(id);
        if (reserva == null)
        {
            _logger.LogError("ReservaSalaController - Metódo Get - Reserva de sala não encontrada");
            return BadRequest("Reserva não encontrada");
        }
        return Ok(reserva);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservaSala>>> GetAll()
    {
        var reservas = await _uof.ReservasSalas.GetAllAsync();
        if (reservas == null || !reservas.Any())
        {
            return BadRequest("Nenhuma reserva cadastrada");
        }
        return Ok(reservas);
    }

    [HttpPost]
    public async Task<ActionResult<ReservaSala>> Create(ReservaSalaDto reservaSalaDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var sala = await _uof.Salas.FindAsync(s => s.Nome == reservaSalaDto.SalaNome);
        var professor = await _uof.Professores.FindAsync(p => p.Nome == reservaSalaDto.ProfessorNome);

        var reserva = new ReservaSala
        {
            Data = reservaSalaDto.Data,
            Turno = reservaSalaDto.Turno,
            Descricao = reservaSalaDto.Descricao,
            Sala = sala,
            Professor = professor,
        };

        return Ok(reserva);
        
    }
}
