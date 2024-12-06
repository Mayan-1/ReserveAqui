using FluentValidation;

namespace ReserveAqui.Application.UseCases.Turma.Criar;

public sealed class CriarTurmaValidator : AbstractValidator<CriarTurmaRequest>
{
    public CriarTurmaValidator()
    {
        RuleFor(x => x.Nome).NotEmpty();
        RuleFor(x => x.QuantidadeAlunos).NotEmpty();
        RuleFor(x => x.Turno).NotEmpty();
        RuleFor(x => x.Codigo).NotEmpty();
    }
}
