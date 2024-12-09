using MediatR;

namespace ReserveAqui.Application.UseCases.Auth.Revoke
{
    public sealed record RevokeRequest(string Email) : IRequest<RevokeResponse>;


}
