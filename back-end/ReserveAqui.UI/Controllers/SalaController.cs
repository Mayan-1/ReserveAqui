using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.Administrador.Atualizar;
using ReserveAqui.Application.UseCases.Administrador.Criar;
using ReserveAqui.Application.UseCases.Administrador.Deletar;
using ReserveAqui.Application.UseCases.Administrador.Obter;
using ReserveAqui.Application.UseCases.Administrador.ObterTodos;
using ReserveAqui.Application.UseCases.Sala.Atualizar;
using ReserveAqui.Application.UseCases.Sala.Criar;
using ReserveAqui.Application.UseCases.Sala.Deletar;
using ReserveAqui.Application.UseCases.Sala.Obter;
using ReserveAqui.Application.UseCases.Sala.ObterTodos;

namespace ReserveAqui.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterSalaResponse>> Obter(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterSalaRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ObterTodasSalasResponse>>> ObterTodos(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodasSalasRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Criar(CriarSalaRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizarSalaRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeletarSalaRequest(id), cancellationToken);
            return Ok(response);
        }
    }
}
