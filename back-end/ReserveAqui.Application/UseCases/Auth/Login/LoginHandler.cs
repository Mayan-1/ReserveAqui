﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ReserveAqui.Application.Services.Token;
using ReserveAqui.Core.Interfaces.Repositories.AdministradorRepository;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Identity.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ReserveAqui.Application.UseCases.Auth.Login;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IProfessorRepository _professorRepository;
    private readonly IAdministradorRepository _administradorRepository;

    public LoginHandler(ITokenService tokenService, UserManager<ApplicationUser> userManager, IConfiguration configuration, IProfessorRepository professorRepository, IAdministradorRepository administradorRepository)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _configuration = configuration;
        _professorRepository = professorRepository;
        _administradorRepository = administradorRepository;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email!);

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password!))
        {
            throw new InvalidOperationException("Email ou senha inválidos.");
        }
        var userRoles = await _userManager.GetRolesAsync(user);


        var authClaims = new List<Claim>
            {

            
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            if(userRole.Equals("professor", StringComparison.OrdinalIgnoreCase))
            {
                var professor = await _professorRepository.ObterProfessorPorNome(user.UserName);
                if (professor != null)
                {
                    authClaims.Add(new Claim("ProfessorId", professor.Id.ToString())); 
                }
            }

            if(userRole.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                var administrador = await _administradorRepository.ObterAdministradorPorNome(user.UserName);
                if(administrador != null)
                {
                    authClaims.Add(new Claim("AdministradorId", administrador.Id.ToString()));
                }
            }
        }

        var token = _tokenService.GenerateAcessToken(authClaims,
            _configuration);

        var refreshToken = _tokenService.GenerateRefreshToken();

        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"],
            out int refreshTokenValidityInMinutes);

        user.RefreshTokenExpiryTime =
            DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

        user.RefreshToken = refreshToken;

        await _userManager.UpdateAsync(user);

        var response = new LoginResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            RefreshToken = refreshToken,
            Expiration = token.ValidTo,
        };

        return response;


    }
}
