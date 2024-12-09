using MediatR;


namespace ReserveAqui.Application.UseCases.Auth.RefreshToken
{
    public sealed record RefreshTokenRequest(string AccessToken, string RefreshToken) : IRequest<RefreshTokenResponse>;
}
