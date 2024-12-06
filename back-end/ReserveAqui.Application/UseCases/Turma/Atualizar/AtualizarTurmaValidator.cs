using FluentValidation;

namespace ReserveAqui.Application.UseCases.Turma.Atualizar; 

public sealed class AtualizarTurmaValidator : AbstractValidator<AtualizarTurmaRequest>
{
    public AtualizarTurmaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Nome).NotEmpty();
        RuleFor(x => x.QuantidadeAlunos).NotEmpty();
        RuleFor(x => x.Turno).NotEmpty();
        RuleFor(x => x.Codigo).NotEmpty();
    }
}
