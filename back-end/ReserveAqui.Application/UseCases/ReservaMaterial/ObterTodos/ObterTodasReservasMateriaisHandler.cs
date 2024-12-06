using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.ObterTodos;

public sealed class ObterTodasReservasMateriaisHandler : IRequestHandler<ObterTodasReservasMateriaisRequest, ICollection<ObterTodasReservasMateriaisResponse>>
{
    private readonly IReservaMaterialRepository _reservaMaterialRepository;
    private readonly IMapper _mapper;

    public ObterTodasReservasMateriaisHandler(IReservaMaterialRepository reservaMaterialRepository, IMapper mapper)
    {
        _reservaMaterialRepository = reservaMaterialRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterTodasReservasMateriaisResponse>> Handle(ObterTodasReservasMateriaisRequest request, CancellationToken cancellationToken)
    {
        var reservas = await _reservaMaterialRepository.ObterTodos(cancellationToken);
        if (reservas == null) return null;

        return _mapper.Map<ICollection<ObterTodasReservasMateriaisResponse>>(reservas);
    }
}
