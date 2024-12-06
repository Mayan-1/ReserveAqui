using FluentValidation;

namespace ReserveAqui.Application.UseCases.Materias.Deletar;

public class DeletarMateriaValidator : AbstractValidator<DeletarMateriaRequest>
{
    public DeletarMateriaValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("O id não pode ser vazio.");
    }
}
