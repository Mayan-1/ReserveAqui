using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases;
using ReserveAqui.Application.UseCases.Professores.Criar;

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
        public async Task<ActionResult<CriarProfessorResponse>> Criar(CriarProfessorRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var response = _mediator.Send(request);
            return Ok(response);
        }
    }
}
