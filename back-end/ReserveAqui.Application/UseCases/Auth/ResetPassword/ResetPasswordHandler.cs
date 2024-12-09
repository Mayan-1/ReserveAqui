using ReserveAqui.Infra.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace ReserveAqui.Application.UseCases.Auth.ResetPassword;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, ResetPasswordResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ResetPasswordHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ResetPasswordResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
            return new ResetPasswordResponse { Message = "Os campos são obrigatórios" };

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return new ResetPasswordResponse { Message = "Usuário não encontrado." };

        var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));

        var result = await _userManager.ResetPasswordAsync(user, decodedToken, request.NewPassword);

        if (result.Succeeded)
            return new ResetPasswordResponse { Message = "Senha atualizada com sucesso!" };

        return new ResetPasswordResponse { Message = "Error ao resetar a senha" };
    }
}
