using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
}
