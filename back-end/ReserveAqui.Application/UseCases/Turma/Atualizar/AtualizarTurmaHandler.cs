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
    public AtualizarTurmaHandler(ITurmaRepository turmaRepository, IUnitOfWork uof, ITurnoRepository turnoRepository)
    {
        _turmaRepository = turmaRepository;
        _uof = uof;
        _turnoRepository = turnoRepository;
    }

    public async Task<AtualizarTurmaResponse> Handle(AtualizarTurmaRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine("turno passado", request.Turno);

        var turma = await _turmaRepository.Obter(request.Id, cancellationToken);
        if (turma == null)
        {
            throw new ArgumentNullException("TURMA NÃO ENCONTRADA");
            return new AtualizarTurmaResponse { Mensagem = "Turma não encontrada" };
        }

        var turno = await _turnoRepository.ObterPorNome(request.Turno);
        Console.WriteLine("turno", turno);
        if (turno == null)
        {
            throw new ArgumentNullException("TURNO NÃO ENCONTRADO");
            return new AtualizarTurmaResponse { Mensagem = "Turno não encontrado" };
        }


        turma.Nome = request.Nome;
        turma.Codigo = request.Codigo;
        turma.QuantidadeAlunos = request.QuantidadeAlunos;
        turma.Turno = turno;

        _turmaRepository.Atualizar(turma);
        await _uof.Commit(cancellationToken);
        return new AtualizarTurmaResponse { Mensagem = "Turma atualizada com sucesso." };

    }
}
