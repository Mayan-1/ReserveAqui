
using FluentValidation;

namespace ReserveAqui.Application.UseCases.Material.Deletar;

public class DeletarMaterialValidator : AbstractValidator<DeletarMaterialRequest>
{
    public DeletarMaterialValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
