using FluentValidation;

namespace ReserveAqui.Application.UseCases.Professores.Deletar;
public class DeletarProfessorValidator : AbstractValidator<DeletarProfessorRequest>
{
    public DeletarProfessorValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id não pode ser vazio");
    }
}
