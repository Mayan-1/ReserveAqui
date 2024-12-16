using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.ReservaSala.Atualizar;
using ReserveAqui.Application.UseCases.ReservaSala.Criar;
using ReserveAqui.Application.UseCases.ReservaSala.Deletar;
using ReserveAqui.Application.UseCases.ReservaSala.Obter;
using ReserveAqui.Application.UseCases.ReservaSala.ObterComFiltro;
using ReserveAqui.Application.UseCases.ReservaSala.ObterTodas;

namespace ReserveAqui.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaSalaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaSalaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("professor/{id}")]
        public async Task<ActionResult<ICollection<ObterTodasReservasSalasResponse>>> ObterTodas(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodasReservasSalasRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterReservaSalaResponse>> Obter(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterReservaSalaRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("filtro")]
        public async Task<ActionResult<ICollection<ObterComFiltroResponse>>> ObterComFiltro(
            [FromHeader (Name = "Sala")] string sala, 
            [FromHeader (Name = "Turno")] string turno, 
            CancellationToken cancellationToken)
        {
            var request = new ObterComFiltroRequest();
            request.Sala = sala;
            request.Turno = turno;
            var response = await _mediator.Send(request, cancellationToken);

            var datasReservadas = response.Select(r => r.Data.ToString("yyyy-MM-dd")).ToList();
            return Ok(datasReservadas);
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromHeader(Name = "idProfessor")] int idProfessor, [FromBody] CriarReservaSalaRequest request, CancellationToken cancellationToken)
        {
            request.IdProfessor = idProfessor;
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar([FromHeader(Name = "idProfessor")] int idProfessor, int id, [FromBody] AtualizarReservaSalaRequest request, CancellationToken cancellationToken)
        {

            request.IdProfessor = idProfessor;
            request.Id = id;

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeletarReservaSalaRequest(id), cancellationToken);
            return Ok(response);
        }

    }
}
