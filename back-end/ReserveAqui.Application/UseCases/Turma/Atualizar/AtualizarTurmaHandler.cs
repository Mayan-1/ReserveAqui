using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.TurmaRepository;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;
using System.Security.Cryptography;

namespace ReserveAqui.Application.UseCases.Turma.Atualizar;

public sealed class AtualizarTurmaHandler : IRequestHandler<AtualizarTurmaRequest, AtualizarTurmaResponse>
{
    private readonly ITurmaRepository _turmaRepository;
    private readonly ITurnoRepository _turnoRepository;
    private readonly IUnitOfWork _uof;
    public AtualizarTurmaHandler(ITurmaRepository turmaRepository, IUnitOfWork uof)
    {
        _turmaRepository = turmaRepository;
        _uof = uof;
    }

    public async Task<AtualizarTurmaResponse> Handle(AtualizarTurmaRequest request, CancellationToken cancellationToken)
    {
        var turma = await _turmaRepository.Obter(request.Id, cancellationToken);
        if (turma == null) return new AtualizarTurmaResponse { Mensagem = "Turma não encontrada" };

        var turno = await _turnoRepository.ObterPorNome(request.Turno);
        if (turno == null) return new AtualizarTurmaResponse { Mensagem = "Turno não encontrado" };

        turma.Nome = request.Nome;
        turma.Codigo = request.Codigo;
        turma.QuantidadeAlunos = request.QuantidadeAlunos;
        turma.Turno = turno;

        _turmaRepository.Atualizar(turma);
        await _uof.Commit(cancellationToken);
        return new AtualizarTurmaResponse { Mensagem = "Turma atualizada com sucesso." };

    }
}
