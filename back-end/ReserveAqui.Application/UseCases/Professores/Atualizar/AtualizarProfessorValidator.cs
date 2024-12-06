using FluentValidation;

namespace ReserveAqui.Application.UseCases.Professores.Atualizar;

public class AtualizarProfessorValidator : AbstractValidator<AtualizarProfessorRequest>
{
    public AtualizarProfessorValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("O id não pode ser vazio.");
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome não pode ser vazio");

        RuleFor(x => x.Email).NotEmpty().WithMessage("O email não pode ser vazio.")
            .MaximumLength(45).WithMessage("O email não pode ter mais de 45 caracteres.")
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(x => x.Telefone).NotEmpty().WithMessage("O telefone não pode ser vazio.");
        RuleFor(x => x.Cpf).NotEmpty().WithMessage("O cpf não pode ser vazio");
        RuleFor(x => x.Materia).NotEmpty().WithMessage("A matéria não pode ser vazia");
        RuleFor(x => x.Instituicao).NotEmpty().WithMessage("A instituição não pode ser vazia");
    }
}
