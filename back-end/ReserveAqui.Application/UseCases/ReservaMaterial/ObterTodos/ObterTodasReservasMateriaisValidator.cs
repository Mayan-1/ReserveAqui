
using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.ObterTodos;

public sealed class ObterTodasReservasMateriaisValidator : AbstractValidator<ObterTodasReservasMateriaisRequest>
{
    public ObterTodasReservasMateriaisValidator()
    {
        // no validation
    }
}
