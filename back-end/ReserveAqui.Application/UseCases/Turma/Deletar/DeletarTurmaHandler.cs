using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.TurmaRepository;

namespace ReserveAqui.Application.UseCases.Turma.Deletar;

public class DeletarTurmaHandler : IRequestHandler<DeletarTurmaRequest, DeletarTurmaResponse>
{
    private readonly ITurmaRepository _turmaRepository;
    private readonly IUnitOfWork _uof;

    public DeletarTurmaHandler(ITurmaRepository turmaRepository, IUnitOfWork uof)
    {
        _turmaRepository = turmaRepository;
        _uof = uof;
    }

    public async Task<DeletarTurmaResponse> Handle(DeletarTurmaRequest request, CancellationToken cancellationToken)
    {
        var turma = await _turmaRepository.Obter(request.Id, cancellationToken);
        if (turma == null) return new DeletarTurmaResponse { Mensagem = "Turma não encontrada" };

        _turmaRepository.Deletar(turma);
        await _uof.Commit(cancellationToken);
        return new DeletarTurmaResponse { Mensagem = "Turma deletada com sucesso." };


    }
}
