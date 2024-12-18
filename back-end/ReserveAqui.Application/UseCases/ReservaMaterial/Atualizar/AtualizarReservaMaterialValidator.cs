using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Atualizar;

public sealed class AtualizarReservaMaterialValidator : AbstractValidator<AtualizarReservaMaterialRequest>
{
    public AtualizarReservaMaterialValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Data).NotEmpty();
        RuleFor(x => x.Material).NotEmpty();
        RuleFor(x => x.IdProfessor).NotEmpty();
        RuleFor(x => x.Descricao).NotEmpty();
        RuleFor(x => x.Turno).NotEmpty();
    }
}
