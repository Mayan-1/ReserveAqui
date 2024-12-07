using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaSala.Deletar;

public sealed class DeletarReservaSalaValidator : AbstractValidator<DeletarReservaSalaRequest>
{
    public DeletarReservaSalaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
