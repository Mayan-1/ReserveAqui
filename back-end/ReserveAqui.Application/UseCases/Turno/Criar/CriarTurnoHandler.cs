using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;

namespace ReserveAqui.Application.UseCases.Turno.Criar;

public sealed class CriarTurnoHandler : IRequestHandler<CriarTurnoRequest, CriarTurnoResponse>
{
    private readonly ITurnoRepository _turnoRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uof;

    public CriarTurnoHandler(ITurnoRepository turnoRepository, IMapper mapper, IUnitOfWork uof)
    {
        _turnoRepository = turnoRepository;
        _mapper = mapper;
        _uof = uof;
    }

    public async Task<CriarTurnoResponse> Handle(CriarTurnoRequest request, CancellationToken cancellationToken)
    {
        var turno = _mapper.Map<Core.Models.Turno>(request);

        _turnoRepository.Criar(turno);
        await _uof.Commit(cancellationToken);
        return new CriarTurnoResponse { Mensagem = "Turno criado com sucesso" };
    }
}
