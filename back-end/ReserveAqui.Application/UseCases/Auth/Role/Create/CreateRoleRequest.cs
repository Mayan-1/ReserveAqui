using MediatR;

namespace ReserveAqui.Application.UseCases.Auth.Role.Create
{
    public sealed record CreateRoleRequest(string RoleName) : IRequest<CreateRoleResponse>;
}
