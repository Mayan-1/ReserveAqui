using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.Materias.Atualizar;
using ReserveAqui.Application.UseCases.Materias.Criar;
using ReserveAqui.Application.UseCases.Materias.Deletar;
using ReserveAqui.Application.UseCases.Materias.Obter;
using ReserveAqui.Application.UseCases.Materias.ObterTodos;

namespace ReserveAqui.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MateriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Criar(CriaMateriaRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterMateriaResponse>> Obter(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterMateriaRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ObterMateriaResponse>>> ObterTodas(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodasMateriasRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeletarMateriaRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizarMateriaRequest request, CancellationToken cancellationToken)
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
