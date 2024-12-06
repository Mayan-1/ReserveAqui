using FluentValidation;

namespace ReserveAqui.Application.UseCases.Sala.Criar;

public class CriarSalaValidator : AbstractValidator<CriarSalaRequest>
{
    public CriarSalaValidator()
    {
        RuleFor(x => x.Nome).NotEmpty();
        RuleFor(x => x.Capacidade).NotEmpty();
        RuleFor(x => x.Tipo).NotEmpty();
    }
}
