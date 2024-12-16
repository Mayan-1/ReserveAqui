using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;
using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;

namespace ReserveAqui.Application.UseCases.ReservaSala.ObterComFiltro;

public class ObterComFiltroHandler : IRequestHandler<ObterComFiltroRequest, ICollection<ObterComFiltroResponse>>
{
    private readonly IReservaSalaRepository _reservaSalaRepository;
    private readonly ITurnoRepository _turnoRepository;
    private readonly ISalaRepository _salaRepository;
    private readonly IMapper _mapper;

    public ObterComFiltroHandler(IReservaSalaRepository reservaSalaRepository, ITurnoRepository turnoRepository, ISalaRepository salaRepository, IMapper mapper)
    {
        _reservaSalaRepository = reservaSalaRepository;
        _turnoRepository = turnoRepository;
        _salaRepository = salaRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterComFiltroResponse>> Handle(ObterComFiltroRequest request, CancellationToken cancellationToken)
    {
        var sala = await _salaRepository.ObterSalaPorNome(request.Sala);
        var turno = await _turnoRepository.ObterPorNome(request.Turno);
        var reservas = await _reservaSalaRepository.ObterReservasComFiltro(sala, turno, cancellationToken);


        return _mapper.Map<ICollection<ObterComFiltroResponse>>(reservas);
    }
}
