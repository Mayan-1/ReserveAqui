using FluentValidation;

namespace ReserveAqui.Application.UseCases.Administrador.ObterTodos;

public class ObterTodosAdministradoresValidator : AbstractValidator<ObterTodosAdministradoresRequest>
{
    public ObterTodosAdministradoresValidator()
    {
        // no validation
    }
}
