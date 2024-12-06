using FluentValidation;

namespace ReserveAqui.Application.UseCases.Sala.ObterTodos;

public class ObterTodasSalasValidator : AbstractValidator<ObterTodasSalasRequest>
{
    public ObterTodasSalasValidator()
    {
        // no validation
    }
}
