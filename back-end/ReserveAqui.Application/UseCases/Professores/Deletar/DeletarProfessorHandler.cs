using MediatR;
using Microsoft.AspNetCore.Identity;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Infra.Identity.User;

namespace ReserveAqui.Application.UseCases.Professores.Deletar;

public class DeletarProfessorHandler : IRequestHandler<DeletarProfessorRequest, DeletarProfessorResponse>
{
    private readonly IProfessorRepository _professorRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUnitOfWork _uof;

    public DeletarProfessorHandler(IProfessorRepository professorRepository, UserManager<ApplicationUser> userManager, IUnitOfWork uof)
    {
        _professorRepository = professorRepository;
        _userManager = userManager;
        _uof = uof;
    }

    public async Task<DeletarProfessorResponse> Handle(DeletarProfessorRequest request, CancellationToken cancellationToken)
    {
        var professor = await _professorRepository.ObterProfessor(request.Id, cancellationToken);
        var user = await _userManager.FindByEmailAsync(professor.Email);


        if (professor == null || user == null)
        {
            return new DeletarProfessorResponse { Mensagem = "Professor não encontrado" };
        }


        _professorRepository.Deletar(professor);
        await _userManager.DeleteAsync(user);

        await _uof.Commit(cancellationToken);
        return new DeletarProfessorResponse { Mensagem = "Professor deletado com sucesso" };


    }
}
