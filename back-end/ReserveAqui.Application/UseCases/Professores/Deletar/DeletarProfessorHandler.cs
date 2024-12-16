using MediatR;
using Microsoft.AspNetCore.Identity;
using ReserveAqui.Application.UseCases.Professores.Deletar;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Infra.Identity.User;
using ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;
using ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;
using ReserveAqui.Infra.Config.Repositories.ReservaSalaRepository;

public class DeletarProfessorHandler : IRequestHandler<DeletarProfessorRequest, DeletarProfessorResponse>
{
    private readonly IProfessorRepository _professorRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUnitOfWork _uof;
    private readonly IReservaSalaRepository _reservaSalaRepository;
    private readonly IReservaMaterialRepository _reservaMaterialRepository;

    public DeletarProfessorHandler(IProfessorRepository professorRepository,
                                   UserManager<ApplicationUser> userManager,
                                   IUnitOfWork uof,
                                   IReservaSalaRepository reservaSalaRepository,
                                   IReservaMaterialRepository reservaMaterialRepository)
    {
        _professorRepository = professorRepository;
        _userManager = userManager;
        _uof = uof;
        _reservaSalaRepository = reservaSalaRepository;  
        _reservaMaterialRepository = reservaMaterialRepository;
    }

    public async Task<DeletarProfessorResponse> Handle(DeletarProfessorRequest request, CancellationToken cancellationToken)
    {
        var professor = await _professorRepository.ObterProfessor(request.Id, cancellationToken);
        var user = await _userManager.FindByEmailAsync(professor.Email);

        if (professor == null || user == null)
        {
            return new DeletarProfessorResponse { Mensagem = "Professor não encontrado" };
        }

        // Excluindo as reservas associadas ao professor
        var reservasSalas = await _reservaSalaRepository.ObterReservasPorProfessor(professor.Id, cancellationToken);
        var reservasMateriais = await _reservaMaterialRepository.ObterReservasPorProfessor(professor.Id, cancellationToken);
        if (reservasSalas.Any())
        {
            foreach (var reserva in reservasSalas)
            {
                _reservaSalaRepository.Deletar(reserva);
            }
        }
        
        if (reservasMateriais.Any())
        {
            foreach (var reserva in reservasMateriais)
            {
                _reservaMaterialRepository.Deletar(reserva);
            }
        }

        // Agora, excluindo o professor e o usuário
        _professorRepository.Deletar(professor);
        await _userManager.DeleteAsync(user);

        await _uof.Commit(cancellationToken);
        return new DeletarProfessorResponse { Mensagem = "Professor deletado com sucesso" };
    }
}
