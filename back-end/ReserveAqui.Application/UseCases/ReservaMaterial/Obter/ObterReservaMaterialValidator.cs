using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Obter;

public sealed class ObterReservaMaterialValidator : AbstractValidator<ObterReservaMaterialRequest>
{
    public ObterReservaMaterialValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
