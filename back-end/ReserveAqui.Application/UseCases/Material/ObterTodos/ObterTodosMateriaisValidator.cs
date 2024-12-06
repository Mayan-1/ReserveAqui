using FluentValidation;

namespace ReserveAqui.Application.UseCases.Material.ObterTodos;

public class ObterTodosMateriaisValidator : AbstractValidator<ObterTodosMateriaisRequest>
{
    public ObterTodosMateriaisValidator()
    {
        // no validation
    }
}
