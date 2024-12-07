using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.ReservaSala.Atualizar;
using ReserveAqui.Application.UseCases.ReservaSala.Criar;
using ReserveAqui.Application.UseCases.ReservaSala.Deletar;
using ReserveAqui.Application.UseCases.ReservaSala.Obter;
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

        [HttpGet]
        public async Task<ActionResult<ICollection<ObterTodasReservasSalasResponse>>> ObterTodas(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodasReservasSalasRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterReservaSalaResponse>> Obter(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterReservaSalaRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Criar(CriarReservaSalaRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizarReservaSalaRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id) return BadRequest();

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
