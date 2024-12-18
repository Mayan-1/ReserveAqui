using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.ReservaMaterial.Atualizar;
using ReserveAqui.Application.UseCases.ReservaMaterial.Criar;
using ReserveAqui.Application.UseCases.ReservaMaterial.Deletar;
using ReserveAqui.Application.UseCases.ReservaMaterial.Obter;
using ReserveAqui.Application.UseCases.ReservaMaterial.ObterComFiltro;
using ReserveAqui.Application.UseCases.ReservaMaterial.ObterTodos;
using ReserveAqui.Application.UseCases.ReservaSala.Criar;
using ReserveAqui.Application.UseCases.ReservaSala.ObterComFiltro;

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

        [HttpGet("professor/{id}")]
        public async Task<ActionResult<ICollection<ObterTodasReservasMateriaisResponse>>> ObterTodas(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterTodasReservasMateriaisRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObterReservaMaterialResponse>> Obter(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ObterReservaMaterialRequest(id), cancellationToken);
            return Ok(response);    
        }

        [HttpGet("filtro")]
        public async Task<ActionResult<ICollection<ObterReservaMaterialComFiltroResponse>>> ObterComFiltro(
            [FromHeader(Name = "Material")] string material,
            [FromHeader(Name = "Turno")] string turno,
            CancellationToken cancellationToken)
        {
            var request = new ObterReservaMaterialComFiltroRequest();
            request.Material = material;
            request.Turno = turno;
            var response = await _mediator.Send(request, cancellationToken);

            var datasReservadas = response.Select(r => r.Data.ToString("yyyy-MM-dd")).ToList();
            return Ok(datasReservadas);
        }

        [HttpPost]
        public async Task<ActionResult> Criar([FromHeader(Name = "idProfessor")] int idProfessor, [FromBody] CriarReservaMaterialRequest request, CancellationToken cancellationToken)
        {
            request.IdProfessor = idProfessor;
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar([FromHeader(Name = "idProfessor")] int idProfessor, int id, AtualizarReservaMaterialRequest request, CancellationToken cancellationToken)
        {
            request.IdProfessor = idProfessor;
            request.Id = id;

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
