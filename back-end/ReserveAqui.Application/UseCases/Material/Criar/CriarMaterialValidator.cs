using FluentValidation;

namespace ReserveAqui.Application.UseCases.Material.Criar;

public sealed class CriarMaterialValidator : AbstractValidator<CriarMaterialRequest>
{
    public CriarMaterialValidator()
    {
        RuleFor(x => x.Nome).NotEmpty();
        RuleFor(x => x.Quantidade).NotEmpty();
        RuleFor(x => x.Tipo).NotEmpty();
    }
}
