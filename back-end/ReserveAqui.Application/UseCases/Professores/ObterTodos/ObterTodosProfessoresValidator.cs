using FluentValidation;

namespace ReserveAqui.Application.UseCases.Professores.ObterTodos;

public class ObterTodosProfessoresValidator : AbstractValidator<ObterTodosProfessoresRequest>
{
    public ObterTodosProfessoresValidator()
    {
        // no validation
    }
}
