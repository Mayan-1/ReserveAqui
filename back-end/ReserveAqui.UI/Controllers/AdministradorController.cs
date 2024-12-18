using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.Administrador.Atualizar;
using ReserveAqui.Application.UseCases.Administrador.Criar;
using ReserveAqui.Application.UseCases.Administrador.Deletar;
using ReserveAqui.Application.UseCases.Administrador.Obter;
using ReserveAqui.Application.UseCases.Administrador.ObterTodos;

namespace ReserveAqui.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdministradorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdministradorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ObterAdministradorResponse>> Obter(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new ObterAdministradorRequest(id), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<ObterAdministradorResponse>>> ObterTodos(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new ObterTodosAdministradoresRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Criar(CriarAdministradorRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine("request valores: ", request.Nome, request.Cpf, request.Telefone, request.Email, request.Senha);
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);   
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(int id, AtualizarAdministradorRequest request, CancellationToken cancellationToken)
    {
        request.Id = id;

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Deletar(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeletarAdministradorRequest(id), cancellationToken);
        return Ok(response);
    }
}
