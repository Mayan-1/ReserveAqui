using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaSala.Criar;

public sealed class CriarReservaSalaValidator : AbstractValidator<CriarReservaSalaRequest>
{
    public CriarReservaSalaValidator()
    {
        RuleFor(x => x.Data).NotEmpty();
        RuleFor(x => x.Sala).NotEmpty();
        RuleFor(x => x.IdProfessor).NotEmpty();
        RuleFor(x => x.Descricao).NotEmpty();
        RuleFor(x => x.Turno).NotEmpty();
    }
}
