using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using ReserveAqui.Application.UseCases.Professores.Criar;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.AdministradorRepository;
using ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;
using ReserveAqui.Infra.Identity.User;
using System.Text;

namespace ReserveAqui.Application.UseCases.Administrador.Criar;

public class CriarAdministradorHandler : IRequestHandler<CriarAdministradorRequest, CriarAdministradorResponse>
{
    private readonly IAdministradorRepository _administradorRepository;
    private readonly IInstituicaoRepository _instituicaoRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailSender _sender;

    public CriarAdministradorHandler(IAdministradorRepository administradorRepository, IInstituicaoRepository instituicaoRepository, IUnitOfWork uof, IMapper mapper, UserManager<ApplicationUser> userManager, IEmailSender sender)
    {
        _administradorRepository = administradorRepository;
        _instituicaoRepository = instituicaoRepository;
        _uof = uof;
        _mapper = mapper;
        _userManager = userManager;
        _sender = sender;
    }

    public async Task<CriarAdministradorResponse> Handle(CriarAdministradorRequest request, CancellationToken cancellationToken)
    {
        var administrador = _mapper.Map<Core.Models.Administrador>(request);

        var instituicao = await _instituicaoRepository.ObterPorNome(request.Instituicao);
        if (instituicao == null)
            return new CriarAdministradorResponse { Mensagem = "Instituição não encontrada" };

        administrador.Instituicao = instituicao;

        var userExists = await _userManager.FindByEmailAsync(administrador.Email);
        if (userExists != null)
            return new CriarAdministradorResponse { Mensagem = "Usuario já existe" };

        var userName = request.Nome.Replace(" ", "_");

        ApplicationUser user = new()
        {
            UserName = userName,
            SecurityStamp = Guid.NewGuid().ToString(),
            Email = administrador.Email,
        };

        _administradorRepository.Criar(administrador);
        var result = await _userManager.CreateAsync(user, request.Senha!);
        await _uof.Commit(cancellationToken);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => $"{e.Code}: {e.Description}"));
            throw new InvalidOperationException($"Criação de usuario falhou. Erros {errors}");
        }

        await SendConfirmationEmail(user, "https://localhost:7078");

        return new CriarAdministradorResponse { Mensagem = "Administrador criado com sucesso" };


    }

    private async Task SendConfirmationEmail(ApplicationUser user, string baseUrl)
    {
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

        var confirmationLink = $"{baseUrl}/api/auth/confirm-email?userId={user.Id}&token={encodedToken}";

        var subject = "Confirmação de Registro";
        var message = $"Por favor, confirme seu registro clicando no link a seguir: <a href='{confirmationLink}'>Confirmar E-mail</a>";

        await _sender.SendEmailAsync(user.Email, subject, message);

    }
}
