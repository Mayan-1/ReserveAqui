using FluentValidation;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Criar;

public sealed class CriarReservaMaterialValidator : AbstractValidator<CriarReservaMaterialRequest>
{
    public CriarReservaMaterialValidator()
    {
        RuleFor(x => x.Data).NotEmpty();
        RuleFor(x => x.Material).NotEmpty();
        RuleFor(x => x.IdProfessor).NotEmpty();
        RuleFor(x => x.Descricao).NotEmpty();
        RuleFor(x => x.Turno).NotEmpty();
    }
}
