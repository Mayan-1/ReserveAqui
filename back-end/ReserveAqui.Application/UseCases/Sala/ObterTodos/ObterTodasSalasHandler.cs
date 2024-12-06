using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;

namespace ReserveAqui.Application.UseCases.Sala.ObterTodos;

public class ObterTodasSalasHandler : IRequestHandler<ObterTodasSalasRequest, ICollection<ObterTodasSalasResponse>>
{
    private readonly ISalaRepository _salaRepository;
    private readonly IMapper _mapper;
    public ObterTodasSalasHandler(ISalaRepository salaRepository, IMapper mapper)
    {
        _salaRepository = salaRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterTodasSalasResponse>> Handle(ObterTodasSalasRequest request, CancellationToken cancellationToken)
    {
        var salas = await _salaRepository.ObterTodos(cancellationToken);
        if (salas == null)
            return null;

        return _mapper.Map<ICollection<ObterTodasSalasResponse>>(salas);
    }
}
