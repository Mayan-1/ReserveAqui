using FluentValidation;

namespace ReserveAqui.Application.UseCases.Auth.Revoke;

public sealed class RevokeValidator : AbstractValidator<RevokeRequest>
{
    public RevokeValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
    }
}
