using FluentValidation;

namespace ReserveAqui.Application.UseCases.Professores.Obter;

public sealed class ObterProfessorValidator : AbstractValidator<ObterProfessorRequest>
{
    public ObterProfessorValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("O id deve ser informado");
    }
}
