using FluentValidation;

namespace ReserveAqui.Application.UseCases.Instituicoes.Deletar;

public sealed class DeletarInstituicaoValidator : AbstractValidator<DeletarInstituicaoRequest>
{
    public DeletarInstituicaoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
