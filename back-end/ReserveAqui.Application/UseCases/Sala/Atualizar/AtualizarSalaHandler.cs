using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;

namespace ReserveAqui.Application.UseCases.Sala.Atualizar;

public class AtualizarSalaHandler : IRequestHandler<AtualizarSalaRequest, AtualizarSalaResponse>
{
    private readonly ISalaRepository _salaRepository;
    private readonly IUnitOfWork _uof;

    public AtualizarSalaHandler(ISalaRepository salaRepository, IUnitOfWork uof)
    {
        _salaRepository = salaRepository;
        _uof = uof;
    }

    public async Task<AtualizarSalaResponse> Handle(AtualizarSalaRequest request, CancellationToken cancellationToken)
    {
        var sala = await _salaRepository.Obter(request.Id, cancellationToken);
        if (sala == null) return null;

        sala.Nome = request.Nome;
        sala.Tipo = request.Tipo;
        sala.Capacidade = request.Capacidade;

        _salaRepository.Atualizar(sala);
        await _uof.Commit(cancellationToken);
        return new AtualizarSalaResponse { Mensagem = "Sala atualizada com sucesso."};
    }
}
