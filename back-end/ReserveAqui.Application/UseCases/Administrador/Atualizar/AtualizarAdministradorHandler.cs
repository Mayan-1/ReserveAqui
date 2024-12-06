using MediatR;
using Microsoft.AspNetCore.Identity;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.AdministradorRepository;
using ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;
using ReserveAqui.Infra.Identity.User;

namespace ReserveAqui.Application.UseCases.Administrador.Atualizar;

public class AtualizarAdministradorHandler : IRequestHandler<AtualizarAdministradorRequest, AtualizarAdministradorResponse>
{
    private readonly IAdministradorRepository _administradorRepository;
    private readonly IInstituicaoRepository _instituicaoRepository;
    private readonly IUnitOfWork _uof;
    private readonly UserManager<ApplicationUser> _userManager;

    public AtualizarAdministradorHandler(IAdministradorRepository administradorRepository, IInstituicaoRepository instituicaoRepository, IUnitOfWork uof, UserManager<ApplicationUser> userManager)
    {
        _administradorRepository = administradorRepository;
        _instituicaoRepository = instituicaoRepository;
        _uof = uof;
        _userManager = userManager;
    }

    public async Task<AtualizarAdministradorResponse> Handle(AtualizarAdministradorRequest request, CancellationToken cancellationToken)
    {
        var administrador = await _administradorRepository.Obter(request.Id, cancellationToken);
        var user = await _userManager.FindByEmailAsync(administrador.Email);
        if (user == null)
            return new AtualizarAdministradorResponse { Mensagem = "Administrador não localizado" };

        var instituicao = await _instituicaoRepository.ObterPorNome(request.Instituicao);
        if (instituicao == null) return new AtualizarAdministradorResponse { Mensagem = "Instituição não localizada" };

        administrador.Nome = request.Nome;
        administrador.Email = request.Email;
        administrador.Cpf = request.Cpf;
        administrador.Telefone = request.Telefone;
        administrador.Instituicao = instituicao;

        user.Email = request.Email;
        user.UserName = request.Nome;

        _administradorRepository.Atualizar(administrador);
        await _userManager.UpdateAsync(user);
        await _uof.Commit(cancellationToken);
        return new AtualizarAdministradorResponse { Mensagem = "Administrador atualizado com sucesso" };

    }
}
