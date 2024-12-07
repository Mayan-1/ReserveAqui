using AutoMapper;
using MediatR;
using ReserveAqui.Application.UseCases.ReservaMaterial.ObterTodos;
using ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;

namespace ReserveAqui.Application.UseCases.ReservaSala.ObterTodas;

public sealed class ObterTodasReservasSalasHandler : IRequestHandler<ObterTodasReservasSalasRequest, ICollection<ObterTodasReservasSalasResponse>>
{
    private readonly IReservaSalaRepository _reservaSalaRepository;
    private readonly IMapper _mapper;

    public ObterTodasReservasSalasHandler(IReservaSalaRepository reservaSalaRepository, IMapper mapper)
    {
        _reservaSalaRepository = reservaSalaRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterTodasReservasSalasResponse>> Handle(ObterTodasReservasSalasRequest request, CancellationToken cancellationToken)
    {
        var reservas = await _reservaSalaRepository.ObterTodos(cancellationToken);
        if (reservas == null) return null;

        return _mapper.Map<ICollection<ObterTodasReservasSalasResponse>>(reservas);
    }
}
