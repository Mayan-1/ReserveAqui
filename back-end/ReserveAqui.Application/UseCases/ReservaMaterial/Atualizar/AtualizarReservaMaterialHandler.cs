using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Application.UseCases.ReservaMaterial.Criar;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Atualizar;

public sealed class AtualizarReservaMaterialHandler : IRequestHandler<AtualizarReservaMaterialRequest, AtualizarReservaMaterialResponse>
{
    private readonly IReservaMaterialRepository _reservaMaterialRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly ITurnoRepository _turnoRepository;
    private readonly IProfessorRepository _professorRepository;
    private readonly IUnitOfWork _uof;

    public AtualizarReservaMaterialHandler(IReservaMaterialRepository reservaMaterialRepository, IMaterialRepository materialRepository, 
        ITurnoRepository turnoRepository, IProfessorRepository professorRepository, IUnitOfWork uof)
    {
        _reservaMaterialRepository = reservaMaterialRepository;
        _materialRepository = materialRepository;
        _turnoRepository = turnoRepository;
        _professorRepository = professorRepository;
        _uof = uof;
    }

    public async Task<AtualizarReservaMaterialResponse> Handle(AtualizarReservaMaterialRequest request, CancellationToken cancellationToken)
    {
        var turno = await _turnoRepository.ObterPorNome(request.Turno);
        var professor = await _professorRepository.Obter(request.IdProfessor, cancellationToken);
        var material = await _materialRepository.ObterMaterialPorNome(request.Material);

        if (professor == null) return new AtualizarReservaMaterialResponse { Mensagem = "Professor não encontrado" };
        if (turno == null) return new AtualizarReservaMaterialResponse { Mensagem = "Turno não encontrado" };
        if (material == null) return new AtualizarReservaMaterialResponse { Mensagem = "Material não encontrado" };

        var reserva = await _reservaMaterialRepository.Obter(request.Id, cancellationToken);
        if (reserva == null) return new AtualizarReservaMaterialResponse { Mensagem = "Reserva não existe" };

        reserva.Descricao = request.Descricao;
        reserva.Professor = professor;
        reserva.Material = material;
        reserva.Turno = turno;
        reserva.Data = request.Data;

        _reservaMaterialRepository.Atualizar(reserva);
        await _uof.Commit(cancellationToken);
        return new AtualizarReservaMaterialResponse { Mensagem = "Reserva atualizada com sucesso" };

    }
}
