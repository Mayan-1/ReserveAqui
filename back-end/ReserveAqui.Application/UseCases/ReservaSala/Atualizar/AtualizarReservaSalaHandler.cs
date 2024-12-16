using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;
using ReserveAqui.Application.UseCases.ReservaMaterial.Atualizar;
using ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;

namespace ReserveAqui.Application.UseCases.ReservaSala.Atualizar;

public sealed class AtualizarReservaSalaHandler : IRequestHandler<AtualizarReservaSalaRequest, AtualizarReservaSalaResponse>
{
    private readonly IReservaSalaRepository _reservaSalaRepository;
    private readonly ISalaRepository _salaRepository;
    private readonly ITurnoRepository _turnoRepository;
    private readonly IProfessorRepository _professorRepository;
    private readonly IUnitOfWork _uof;

    public AtualizarReservaSalaHandler(IReservaSalaRepository reservaSalaRepository, ISalaRepository salaRepository, ITurnoRepository turnoRepository, 
        IProfessorRepository professorRepository, IUnitOfWork uof)
    {
        _reservaSalaRepository = reservaSalaRepository;
        _salaRepository = salaRepository;
        _turnoRepository = turnoRepository;
        _professorRepository = professorRepository;
        _uof = uof;
    }

    public async Task<AtualizarReservaSalaResponse> Handle(AtualizarReservaSalaRequest request, CancellationToken cancellationToken)
    {
        var turno = await _turnoRepository.ObterPorNome(request.Turno);
        var professor = await _professorRepository.Obter(request.IdProfessor, cancellationToken);
        var sala = await _salaRepository.ObterSalaPorNome(request.Sala);

        if (professor == null) return new AtualizarReservaSalaResponse { Mensagem = "Professor não encontrado" };
        if (turno == null) return new AtualizarReservaSalaResponse { Mensagem = "Turno não encontrado" };
        if (sala == null) return new AtualizarReservaSalaResponse { Mensagem = "Sala não encontrada" };

        var reserva = await _reservaSalaRepository.Obter(request.Id, cancellationToken);
        if (reserva == null) return new AtualizarReservaSalaResponse { Mensagem = "Reserva não existe" };

        reserva.Descricao = request.Descricao;
        reserva.Professor = professor;
        reserva.Sala = sala;
        reserva.Turno = turno;
        reserva.Data = request.Data;

        _reservaSalaRepository.Atualizar(reserva);
        await _uof.Commit(cancellationToken);
        return new AtualizarReservaSalaResponse { Mensagem = "Reserva atualizada com sucesso" };
    }
}
