
using FluentValidation;

namespace ReserveAqui.Application.UseCases.Professores.Criar;

public class CriarProfessorValidator : AbstractValidator<CriarProfessorRequest>
{
    public CriarProfessorValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome não pode ser vazio");

        RuleFor(x => x.Email).NotEmpty().WithMessage("O email não pode ser vazio.")
            .MaximumLength(45).WithMessage("O email não pode ter mais de 45 caracteres.")
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(p => p.Senha).NotEmpty().WithMessage("A senha não pode ser vazia.")
                   .MinimumLength(8).WithMessage("A senha deve conter pelo menos 8 caracteres.")
                   .MaximumLength(16).WithMessage("A senha não pode ter mais de 16 caracteres.")
                   .Matches(@"[A-Z]+").WithMessage("A senha deve conter ao menos uma letra maiuscula.")
                   .Matches(@"[a-z]+").WithMessage("A senha deve conter ao menos uma letra minuscula.")
                   .Matches(@"[0-9]+").WithMessage("A senha deve conter pelo menos um número.")
                   .Matches(@"[\!\?\*\.]+").WithMessage("A senha deve conter pelo menos um caractere especial(!? *.).");
        
        RuleFor(x => x.Telefone).NotEmpty().WithMessage("O telefone não pode ser vazio.");
        RuleFor(x => x.Cpf).NotEmpty().WithMessage("O cpf não pode ser vazio");
        RuleFor(x => x.Materia).NotEmpty().WithMessage("A matéria não pode ser vazia");
    }
}
