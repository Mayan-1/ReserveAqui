using FluentValidation;

namespace ReserveAqui.Application.UseCases.Turma.ObterTodos;

public sealed class ObterTodasTurmasValidator : AbstractValidator<ObterTodasTurmasRequest>
{
    public ObterTodasTurmasValidator()
    {
        // no validation
    }
}
