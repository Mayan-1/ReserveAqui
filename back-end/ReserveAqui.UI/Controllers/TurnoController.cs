using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.Turma.Criar;
using ReserveAqui.Application.UseCases.Turma.ObterTodos;
using ReserveAqui.Application.UseCases.Turno.Criar;
using ReserveAqui.Application.UseCases.Turno.ObterTodos;

namespace ReserveAqui.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TurnoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ObterTodosTurnosResponse>>> ObterTodos(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodosTurnosRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Criar(CriarTurnoRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

    }
}
