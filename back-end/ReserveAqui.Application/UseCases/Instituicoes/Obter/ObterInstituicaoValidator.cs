using FluentValidation;

namespace ReserveAqui.Application.UseCases.Instituicoes.Obter;

public class ObterInstituicaoValidator : AbstractValidator<ObterInstituicaoRequest>
{
    public ObterInstituicaoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
