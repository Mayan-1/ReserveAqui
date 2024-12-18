using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;
using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.ObterComFiltro;

public class ObterReservaMaterialComFiltroHandler : IRequestHandler<ObterReservaMaterialComFiltroRequest, ICollection<ObterReservaMaterialComFiltroResponse>>
{
    private readonly IReservaMaterialRepository _reservaMaterialRepository;
    private readonly ITurnoRepository _turnoRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly IMapper _mapper;

    public ObterReservaMaterialComFiltroHandler(IReservaMaterialRepository reservaMaterialRepository, ITurnoRepository turnoRepository, IMaterialRepository materialRepository, IMapper mapper)
    {
        _reservaMaterialRepository = reservaMaterialRepository;
        _turnoRepository = turnoRepository;
        _materialRepository = materialRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterReservaMaterialComFiltroResponse>> Handle(ObterReservaMaterialComFiltroRequest request, CancellationToken cancellationToken)
    {
        var sala = await _materialRepository.ObterMaterialPorNome(request.Material);
        var turno = await _turnoRepository.ObterPorNome(request.Turno);
        var reservas = await _reservaMaterialRepository.ObterReservasComFiltro(sala, turno, cancellationToken);


        return _mapper.Map<ICollection<ObterReservaMaterialComFiltroResponse>>(reservas);
    }
}
