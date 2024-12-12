using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases;
using ReserveAqui.Application.UseCases.Professores.Atualizar;
using ReserveAqui.Application.UseCases.Professores.Criar;
using ReserveAqui.Application.UseCases.Professores.Deletar;
using ReserveAqui.Application.UseCases.Professores.Obter;
using ReserveAqui.Application.UseCases.Professores.ObterTodos;

namespace ReserveAqui.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfessorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Criar(CriarProfessorRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        //[Authorize (Roles = "admin")]
        public async Task<ActionResult<ICollection<ObterTodosProfessoresResponse>>> ObterTodos(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodosProfessoresRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterTodosProfessoresResponse>> Obter(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterProfessorRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeletarProfessorResponse>> Deletar(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeletarProfessorRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizarProfessorRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
