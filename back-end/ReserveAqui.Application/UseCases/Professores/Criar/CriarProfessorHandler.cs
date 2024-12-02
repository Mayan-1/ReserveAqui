﻿using AutoMapper;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using ReserveAqui.Infra.Identity.User;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace ReserveAqui.Application.UseCases.Professores.Criar;

public class CriarProfessorHandler : IRequestHandler<CriarProfessorRequest, CriarProfessorResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IProfessorRepository _professorRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    private readonly IEmailSender _sender;
    public CriarProfessorHandler(UserManager<ApplicationUser> userManager,
        IProfessorRepository professorRepository, 
        IUnitOfWork uof, 
        IMapper mapper,
        IEmailSender sender)
    {
        _userManager = userManager;
        _professorRepository = professorRepository;
        _uof = uof;
        _mapper = mapper;
        _sender = sender;
    }

    public async Task<CriarProfessorResponse> Handle(CriarProfessorRequest request,
        CancellationToken cancellationToken)
    {
        var professor = _mapper.Map<Professor>(request);

        _professorRepository.Criar(professor);

        var userExists = await _userManager.FindByNameAsync(request.Nome!);

        if (userExists != null)
            throw new InvalidOperationException("O úsuario já existe");

        var UserName = request.Nome.Replace(" ", "_");

        ApplicationUser user = new()
        {
            UserName = UserName,
            SecurityStamp = Guid.NewGuid().ToString(),
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Senha!);
        await _uof.Commit(cancellationToken);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => $"{e.Code}: {e.Description}"));
            throw new InvalidOperationException($"Criação de usuario falhou. Erros {errors}");
        }

        await SendConfirmationEmail(user, "https://localhost:7078");

        return new CriarProfessorResponse { Mensagem = "User created sucessfully" };
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
