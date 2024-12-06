using FluentValidation;

namespace ReserveAqui.Application.UseCases.Turma.Deletar;

public sealed class DeletarTurmaValidator : AbstractValidator<DeletarTurmaRequest>
{
    public DeletarTurmaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
