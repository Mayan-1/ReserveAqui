using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.Material.Atualizar;
using ReserveAqui.Application.UseCases.Material.Criar;
using ReserveAqui.Application.UseCases.Material.Deletar;
using ReserveAqui.Application.UseCases.Material.Obter;
using ReserveAqui.Application.UseCases.Material.ObterTodos;
using ReserveAqui.Application.UseCases.Turma.Atualizar;
using ReserveAqui.Application.UseCases.Turma.Criar;
using ReserveAqui.Application.UseCases.Turma.Deletar;
using ReserveAqui.Application.UseCases.Turma.Obter;
using ReserveAqui.Application.UseCases.Turma.ObterTodos;

namespace ReserveAqui.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TurmaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterTurmaResponse>> Obter(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTurmaRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ObterTodasTurmasResponse>>> ObterTodos(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodasTurmasRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Criar(CriarTurmaRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizarTurmaRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeletarTurmaRequest(id), cancellationToken);
            return Ok(response);
        }
    }
}
