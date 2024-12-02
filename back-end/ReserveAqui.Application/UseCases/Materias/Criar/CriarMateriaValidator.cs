using FluentValidation;

namespace ReserveAqui.Application.UseCases.Materias.Criar;

public class CriarMateriaValidator : AbstractValidator<CriaMateriaRequest>
{
    public CriarMateriaValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome não pode ser vazio");
    }
}
