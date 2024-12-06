using FluentValidation;

namespace ReserveAqui.Application.UseCases.Materias.Obter;

public class ObterMateriaValidator : AbstractValidator<ObterMateriaRequest>
{
    public ObterMateriaValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("O id não pode ser vazio");
    }
}
