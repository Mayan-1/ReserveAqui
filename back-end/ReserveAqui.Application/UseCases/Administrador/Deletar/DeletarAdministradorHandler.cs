using MediatR;
using Microsoft.AspNetCore.Identity;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.AdministradorRepository;
using ReserveAqui.Infra.Identity.User;

namespace ReserveAqui.Application.UseCases.Administrador.Deletar;

public class DeletarAdministradorHandler : IRequestHandler<DeletarAdministradorRequest, DeletarAdministradorResponse>
{
    private readonly IAdministradorRepository _administradorRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUnitOfWork _uof;

    public DeletarAdministradorHandler(IAdministradorRepository administradorRepository, UserManager<ApplicationUser> userManager, IUnitOfWork uof)
    {
        _administradorRepository = administradorRepository;
        _userManager = userManager;
        _uof = uof;
    }

    public async Task<DeletarAdministradorResponse> Handle(DeletarAdministradorRequest request, CancellationToken cancellationToken)
    {
        var administrador = await _administradorRepository.Obter(request.Id, cancellationToken);
       
        if (administrador == null)
            return new DeletarAdministradorResponse { Mensagem = "Administrador não encontrado" };

        var user = await _userManager.FindByEmailAsync(administrador.Email);
        if (user == null)
            return new DeletarAdministradorResponse { Mensagem = "Usuario não encontrado" };

        _administradorRepository.Deletar(administrador);
        await _userManager.DeleteAsync(user);
        await _uof.Commit(cancellationToken);
        return new DeletarAdministradorResponse { Mensagem = "Administrador deletado com sucesso" };

    }
}
