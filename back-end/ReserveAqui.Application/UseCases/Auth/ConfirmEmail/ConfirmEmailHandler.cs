using ReserveAqui.Infra.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace ReserveAqui.Application.UseCases.Auth.ConfirmEmail;

public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailRequest, ConfirmEmailResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ConfirmEmailHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }


    public async Task<ConfirmEmailResponse> Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.UserId) || string.IsNullOrEmpty(request.Token))
            return new ConfirmEmailResponse { Message = "UserId and Token are required" };

        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
            return new ConfirmEmailResponse { Message = "Usuário não encontrado" };

        var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));
        var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

        if (result.Succeeded)
            return new ConfirmEmailResponse { Message = "Email confirmado com sucesso!" };

        throw new Exception("Erro ao confirmar email.");
    }
}
