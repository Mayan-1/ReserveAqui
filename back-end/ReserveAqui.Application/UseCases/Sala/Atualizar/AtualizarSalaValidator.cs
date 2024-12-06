using FluentValidation;

namespace ReserveAqui.Application.UseCases.Sala.Atualizar;

public class AtualizarSalaValidator : AbstractValidator<AtualizarSalaRequest>
{
    public AtualizarSalaValidator()
    {
        RuleFor(x => x.Nome).NotEmpty();
        RuleFor(x => x.Capacidade).NotEmpty();
        RuleFor(x => x.Tipo).NotEmpty();
    }
}
