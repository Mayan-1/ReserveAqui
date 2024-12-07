using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaSala.ObterTodas;

public sealed class ObterTodasReservasSalasValidator : AbstractValidator<ObterTodasReservasSalasRequest>
{
    public ObterTodasReservasSalasValidator()
    {
        // no validation
    }
}
