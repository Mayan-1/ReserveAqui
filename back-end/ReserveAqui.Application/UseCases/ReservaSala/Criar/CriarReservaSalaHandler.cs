using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;
using ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;
using ReserveAqui.Application.UseCases.ReservaMaterial.Criar;

namespace ReserveAqui.Application.UseCases.ReservaSala.Criar;

public sealed class CriarReservaSalaHandler : IRequestHandler<CriarReservaSalaRequest, CriarReservaSalaResponse>
{
    private readonly IReservaSalaRepository _reservaSalaRepository;
    private readonly ISalaRepository _salaRepository;
    private readonly ITurnoRepository _turnoRepository;
    private readonly IProfessorRepository _professorRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public CriarReservaSalaHandler(IReservaSalaRepository reservaSalaRepository, ISalaRepository salaRepository, ITurnoRepository turnoRepository, 
        IProfessorRepository professorRepository, IUnitOfWork uof, IMapper mapper)
    {
        _reservaSalaRepository = reservaSalaRepository;
        _salaRepository = salaRepository;
        _turnoRepository = turnoRepository;
        _professorRepository = professorRepository;
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<CriarReservaSalaResponse> Handle(CriarReservaSalaRequest request, CancellationToken cancellationToken)
    {
        var turno = await _turnoRepository.ObterPorNome(request.Turno);
        var professor = await _professorRepository.Obter(request.IdProfessor, cancellationToken);
        var sala = await _salaRepository.ObterSalaPorNome(request.Sala);

        if (professor == null) return new CriarReservaSalaResponse { Mensagem = "Professor não encontrado" };
        if (turno == null) return new CriarReservaSalaResponse { Mensagem = "Turno não encontrado" };
        if (sala == null) return new CriarReservaSalaResponse { Mensagem = "Sala não encontrada" };

        var reservaExiste = await _reservaSalaRepository.ObterReservaPorData(request.Data, turno, sala, cancellationToken);

        if (reservaExiste) return new CriarReservaSalaResponse { Mensagem = "Reserva para essa data já existe" };

        var reserva = _mapper.Map<Core.Models.ReservaSala>(request);

        reserva.Sala = sala;
        reserva.Professor = professor;
        reserva.Turno = turno;

        _reservaSalaRepository.Criar(reserva);
        await _uof.Commit(cancellationToken);
        return new CriarReservaSalaResponse { Mensagem = "Reserva criada com sucesso" };
    }
}
