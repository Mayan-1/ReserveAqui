using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaSala.ObterComFiltro;

public sealed class ObterComFiltroValidator : AbstractValidator<ObterComFiltroRequest>
{
    public ObterComFiltroValidator()
    {
        RuleFor(x => x.Sala).NotEmpty();
        RuleFor(x => x.Turno).NotEmpty();
    }
}
