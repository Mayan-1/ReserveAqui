using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Deletar;

public sealed class DeletarReservaMaterialValidator : AbstractValidator<DeletarReservaMaterialRequest>
{
    public DeletarReservaMaterialValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
