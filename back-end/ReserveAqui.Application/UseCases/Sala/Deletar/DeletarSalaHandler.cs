using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;

namespace ReserveAqui.Application.UseCases.Sala.Deletar;

public class DeletarSalaHandler : IRequestHandler<DeletarSalaRequest, DeletarSalaResponse>
{
    private readonly ISalaRepository _salaRepository;
    private readonly IUnitOfWork _uof;

    public DeletarSalaHandler(ISalaRepository salaRepository, IUnitOfWork uof)
    {
        _salaRepository = salaRepository;
        _uof = uof;
    }

    public async Task<DeletarSalaResponse> Handle(DeletarSalaRequest request, CancellationToken cancellationToken)
    {
        var sala = await _salaRepository.Obter(request.Id, cancellationToken);
        if (sala == null)
            return null;

        _salaRepository.Deletar(sala);
        await _uof.Commit(cancellationToken);
        return new DeletarSalaResponse { Mensagem = "Sala removida com sucesso." };

    }
}
