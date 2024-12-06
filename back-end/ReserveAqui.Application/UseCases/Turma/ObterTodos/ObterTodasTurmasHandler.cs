
using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.TurmaRepository;

namespace ReserveAqui.Application.UseCases.Turma.ObterTodos;

public sealed class ObterTodasTurmasHandler : IRequestHandler<ObterTodasTurmasRequest, ICollection<ObterTodasTurmasResponse>>
{
    private readonly ITurmaRepository _turmaRepository;
    private readonly IMapper _mapper;
    public ObterTodasTurmasHandler(ITurmaRepository turmaRepository, IMapper mapper)
    {
        _turmaRepository = turmaRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterTodasTurmasResponse>> Handle(ObterTodasTurmasRequest request, CancellationToken cancellationToken)
    {
        var turmas = await _turmaRepository.ObterTodos(cancellationToken);
        if (turmas == null) return null;

        return _mapper.Map<ICollection<ObterTodasTurmasResponse>>(turmas);
    }
}
