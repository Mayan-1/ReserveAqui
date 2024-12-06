using FluentValidation;

namespace ReserveAqui.Application.UseCases.Materias.ObterTodos;
public class ObterTodasMateriasValidator : AbstractValidator<ObterTodasMateriasRequest>
{
    public ObterTodasMateriasValidator()
    {
        // no validation
    }
}
