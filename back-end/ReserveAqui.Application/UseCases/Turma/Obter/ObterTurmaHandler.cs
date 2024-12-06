using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.TurmaRepository;

namespace ReserveAqui.Application.UseCases.Turma.Obter;

public sealed class ObterTurmaHandler : IRequestHandler<ObterTurmaRequest, ObterTurmaResponse>
{
    private readonly ITurmaRepository _turmaRepository;
    private readonly IMapper _mapper;
    public ObterTurmaHandler(ITurmaRepository turmaRepository, IMapper mapper)
    {
        _turmaRepository = turmaRepository;
        _mapper = mapper;
    }

    public async Task<ObterTurmaResponse> Handle(ObterTurmaRequest request, CancellationToken cancellationToken)
    {
        var turma = await _turmaRepository.Obter(request.Id, cancellationToken);
        if (turma == null) return null;

        return _mapper.Map<ObterTurmaResponse>(turma);
    }
}
