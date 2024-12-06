
using FluentValidation;

namespace ReserveAqui.Application.UseCases.Material.Atualizar;

public class AtualizarMaterialValidator : AbstractValidator<AtualizarMaterialRequest>
{
    public AtualizarMaterialValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Nome).NotEmpty();
        RuleFor(x => x.Quantidade).NotEmpty();
        RuleFor(x => x.Tipo).NotEmpty();
    }
}
