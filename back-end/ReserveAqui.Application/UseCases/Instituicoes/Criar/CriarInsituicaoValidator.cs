
using FluentValidation;

namespace ReserveAqui.Application.UseCases.Instituicoes.Criar;

public class CriarInsituicaoValidator : AbstractValidator<CriarInstituicaoRequest>
{
    public CriarInsituicaoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome da instituição não pode ser vazio");
    }
}
