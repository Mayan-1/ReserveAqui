using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;

namespace ReserveAqui.Application.UseCases.Sala.Obter;

public class ObterSalaHandler : IRequestHandler<ObterSalaRequest, ObterSalaResponse>
{
    private readonly ISalaRepository _salaRepository;
    private readonly IMapper _mapper;

    public ObterSalaHandler(ISalaRepository salaRepository, IMapper mapper)
    {
        _salaRepository = salaRepository;
        _mapper = mapper;
    }

    public async Task<ObterSalaResponse> Handle(ObterSalaRequest request, CancellationToken cancellationToken)
    {
        var sala = await _salaRepository.Obter(request.Id, cancellationToken);
        if (sala == null)
            return null;

        return _mapper.Map<ObterSalaResponse>(sala);
    }
}
