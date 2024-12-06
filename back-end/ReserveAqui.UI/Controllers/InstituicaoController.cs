using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.Instituicoes.Atualizar;
using ReserveAqui.Application.UseCases.Instituicoes.Criar;
using ReserveAqui.Application.UseCases.Instituicoes.Deletar;
using ReserveAqui.Application.UseCases.Instituicoes.Obter;
using ReserveAqui.Application.UseCases.Instituicoes.ObterTodos;

namespace ReserveAqui.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstituicaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Criar(CriarInstituicaoRequest request)
        {
            if (request == null) 
            {
                return BadRequest();
            }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterInstituicaoResponse>> Obter(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterInstituicaoRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ObterTodasInstituicoesResponse>>> ObterTodas(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodasInstituicoesRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id, CancellationToken cancellationToken)
        {
            var reponse = await _mediator.Send(new DeletarInstituicaoRequest(id), cancellationToken);
            return Ok(reponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, AtualizarInstituicaoRequest request, CancellationToken cancellationToken)
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
