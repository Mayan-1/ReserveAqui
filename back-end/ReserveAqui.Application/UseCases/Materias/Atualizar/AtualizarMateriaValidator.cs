using FluentValidation;

namespace ReserveAqui.Application.UseCases.Materias.Atualizar;

public class AtualizarMateriaValidator : AbstractValidator<AtualizarMateriaRequest>
{
    public AtualizarMateriaValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("O id não pode ser vazio");
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome não pode ser vazio");
    }
}
