using FluentValidation;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Instituicoes.Atualizar;

public class AtualizarInstituicaoValidator : AbstractValidator<AtualizarInstituicaoRequest>
{
    public AtualizarInstituicaoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Nome).NotEmpty();
    }
}
