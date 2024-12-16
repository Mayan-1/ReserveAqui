using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaSala.Atualizar;

public class AtualizarReservaSalaValidator : AbstractValidator<AtualizarReservaSalaRequest>
{
    public AtualizarReservaSalaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Data).NotEmpty();
        RuleFor(x => x.Sala).NotEmpty();
        RuleFor(x => x.IdProfessor).NotEmpty();
        RuleFor(x => x.Descricao).NotEmpty();
        RuleFor(x => x.Turno).NotEmpty();
    }
}
