using FluentValidation;

namespace ReserveAqui.Application.UseCases.Sala.Obter;

public class ObterSalaValidator : AbstractValidator<ObterSalaRequest>
{
    public ObterSalaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
