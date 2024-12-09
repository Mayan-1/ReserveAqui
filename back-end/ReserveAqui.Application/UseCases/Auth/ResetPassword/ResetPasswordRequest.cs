using MediatR;


namespace ReserveAqui.Application.UseCases.Auth.ResetPassword
{
    public sealed record ResetPasswordRequest(string Email, string Token, string NewPassword)
        : IRequest<ResetPasswordResponse>;

}
