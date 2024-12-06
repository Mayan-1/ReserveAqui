using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;

namespace ReserveAqui.Application.UseCases.Turno.ObterTodos;

public class ObterTodosTurnosHandler : IRequestHandler<ObterTodosTurnosRequest, ICollection<ObterTodosTurnosResponse>>
{
    private readonly ITurnoRepository _turnoRepository;
    private readonly IMapper _mapper;

    public ObterTodosTurnosHandler(ITurnoRepository turnoRepository, IMapper mapper)
    {
        _turnoRepository = turnoRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterTodosTurnosResponse>> Handle(ObterTodosTurnosRequest request, CancellationToken cancellationToken)
    {
        var turnos = await _turnoRepository.ObterTodos(cancellationToken);
        if (turnos == null) return null;

        return _mapper.Map<ICollection<ObterTodosTurnosResponse>>(turnos);
    }
}
