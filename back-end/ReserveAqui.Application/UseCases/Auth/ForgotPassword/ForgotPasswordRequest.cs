using MediatR;

namespace ReserveAqui.Application.UseCases.Auth.ForgotPassword
{
    public sealed record ForgotPasswordRequest(string Email)
        : IRequest<ForgotPasswordResponse>;


}
