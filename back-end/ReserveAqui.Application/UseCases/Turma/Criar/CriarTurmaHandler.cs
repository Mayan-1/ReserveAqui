using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.TurmaRepository;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;

namespace ReserveAqui.Application.UseCases.Turma.Criar;

public class CriarTurmaHandler : IRequestHandler<CriarTurmaRequest, CriarTurmaResponse>
{
    private readonly ITurmaRepository _turmaRepository;
    private readonly ITurnoRepository _turnoRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    public CriarTurmaHandler(ITurmaRepository turmaRepository, ITurnoRepository turnoRepository, IUnitOfWork uof, IMapper mapper)
    {
        _turmaRepository = turmaRepository;
        _turnoRepository = turnoRepository;
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<CriarTurmaResponse> Handle(CriarTurmaRequest request, CancellationToken cancellationToken)
    {
        var turma = _mapper.Map<Core.Models.Turma>(request);

        var turno = await _turnoRepository.ObterPorNome(request.Turno);
        if (turno == null) return new CriarTurmaResponse { Mensagem = "Turno inválido" };

        turma.Turno = turno;

        _turmaRepository.Criar(turma);
        await _uof.Commit(cancellationToken);
        return new CriarTurmaResponse { Mensagem = "Turma criada com sucesso" };
    }
}
