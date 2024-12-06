using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Obter;

public sealed class ObterReservaMaterialHandler : IRequestHandler<ObterReservaMaterialRequest, ObterReservaMaterialResponse>
{
    private readonly IReservaMaterialRepository _reservaMaterialRepository;
    private readonly IMapper _mapper;

    public ObterReservaMaterialHandler(IReservaMaterialRepository reservaMaterialRepository, IMapper mapper)
    {
        _reservaMaterialRepository = reservaMaterialRepository;
        _mapper = mapper;
    }

    public async Task<ObterReservaMaterialResponse> Handle(ObterReservaMaterialRequest request, CancellationToken cancellationToken)
    {
        var reserva = await _reservaMaterialRepository.Obter(request.Id, cancellationToken);
        if (reserva == null) return null;

        return _mapper.Map<ObterReservaMaterialResponse>(reserva);
    }
}
