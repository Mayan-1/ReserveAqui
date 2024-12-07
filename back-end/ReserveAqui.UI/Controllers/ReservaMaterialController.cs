using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.ReservaMaterial.Atualizar;
using ReserveAqui.Application.UseCases.ReservaMaterial.Criar;
using ReserveAqui.Application.UseCases.ReservaMaterial.Deletar;
using ReserveAqui.Application.UseCases.ReservaMaterial.Obter;
using ReserveAqui.Application.UseCases.ReservaMaterial.ObterTodos;

namespace ReserveAqui.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ObterTodasReservasMateriaisResponse>>> ObterTodas(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodasReservasMateriaisRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterReservaMaterialResponse>> Obter(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterReservaMaterialRequest(id), cancellationToken);
            return Ok(response);    
        }

        [HttpPost]
        public async Task<ActionResult> Criar(CriarReservaMaterialRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizarReservaMaterialRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id) return BadRequest();

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeletarReservaMaterialRequest(id), cancellationToken);
            return Ok(response);
        }



    }
}
