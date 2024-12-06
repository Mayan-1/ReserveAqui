
using FluentValidation;

namespace ReserveAqui.Application.UseCases.Material.Obter;

public class ObterMaterialValidator : AbstractValidator<ObterMaterialRequest>
{
    public ObterMaterialValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
