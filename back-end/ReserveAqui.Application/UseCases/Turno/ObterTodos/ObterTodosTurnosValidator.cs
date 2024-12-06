using FluentValidation;

namespace ReserveAqui.Application.UseCases.Turno.ObterTodos;

public class ObterTodosTurnosValidator : AbstractValidator<ObterTodosTurnosRequest>
{
    public ObterTodosTurnosValidator()
    {
        // no validation
    }
}
