using FluentValidation;

namespace ReserveAqui.Application.UseCases.Turno.Criar;

public class CriarTurnoValidator : AbstractValidator<CriarTurnoRequest>
{
    public CriarTurnoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty();
    }
}
