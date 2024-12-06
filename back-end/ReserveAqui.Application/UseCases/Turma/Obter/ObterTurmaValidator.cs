using FluentValidation;

namespace ReserveAqui.Application.UseCases.Turma.Obter;

public sealed class ObterTurmaValidator : AbstractValidator<ObterTurmaRequest>
{
    public ObterTurmaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
