using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Criar;

public sealed class CriarReservaMaterialHandler : IRequestHandler<CriarReservaMaterialRequest, CriarReservaMaterialResponse>
{
    private readonly IReservaMaterialRepository _reservaMaterialRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly ITurnoRepository _turnoRepository;
    private readonly IProfessorRepository _professorRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public CriarReservaMaterialHandler(IReservaMaterialRepository reservaMaterialRepository, IMaterialRepository materialRepository, ITurnoRepository turnoRepository, IProfessorRepository professorRepository, IUnitOfWork uof, IMapper mapper)
    {
        _reservaMaterialRepository = reservaMaterialRepository;
        _materialRepository = materialRepository;
        _turnoRepository = turnoRepository;
        _professorRepository = professorRepository;
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<CriarReservaMaterialResponse> Handle(CriarReservaMaterialRequest request, CancellationToken cancellationToken)
    {
        var turno = await _turnoRepository.ObterPorNome(request.Turno);
        var professor = await _professorRepository.ObterProfessorPorNome(request.Professor);
        var material = await _materialRepository.ObterMaterialPorNome(request.Material);

        if (professor == null) return new CriarReservaMaterialResponse { Mensagem = "Professor não encontrado" };
        if (turno == null) return new CriarReservaMaterialResponse { Mensagem = "Turno não encontrado" };
        if (material == null) return new CriarReservaMaterialResponse { Mensagem = "Material não encontrado" };

        var reservaExiste = await _reservaMaterialRepository.ObterReservaPorData(request.Data, turno, material, cancellationToken);

        if (reservaExiste) return new CriarReservaMaterialResponse { Mensagem = "Reserva para essa data já existe" };

        var reserva = _mapper.Map<Core.Models.ReservaMaterial>(request);
        
        reserva.Material = material;
        reserva.Professor = professor;
        reserva.Turno = turno;

        _reservaMaterialRepository.Criar(reserva);
        await _uof.Commit(cancellationToken);
        return new CriarReservaMaterialResponse { Mensagem = "Reserva criada com sucesso" };


    }
}
