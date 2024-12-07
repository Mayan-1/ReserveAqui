
using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaSala.Obter;

public sealed class ObterReservaSalaValidator : AbstractValidator<ObterReservaSalaRequest>
{
    public ObterReservaSalaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
