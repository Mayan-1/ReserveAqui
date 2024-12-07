using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;

namespace ReserveAqui.Application.UseCases.ReservaSala.Obter;

public sealed class ObterReservaSalaHandler : IRequestHandler<ObterReservaSalaRequest, ObterReservaSalaResponse>
{
    private readonly IReservaSalaRepository _reservaSalaRepository;
    private readonly IMapper _mapper;
    public ObterReservaSalaHandler(IReservaSalaRepository reservaSalaRepository, IMapper mapper)
    {
        _reservaSalaRepository = reservaSalaRepository;
        _mapper = mapper;
    }

    public async Task<ObterReservaSalaResponse> Handle(ObterReservaSalaRequest request, CancellationToken cancellationToken)
    {
        var reserva = await _reservaSalaRepository.Obter(request.Id, cancellationToken);
        if (reserva == null) return null;

        return _mapper.Map<ObterReservaSalaResponse>(reserva);
    }
}
