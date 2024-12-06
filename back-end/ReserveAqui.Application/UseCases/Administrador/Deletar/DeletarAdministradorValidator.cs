using FluentValidation;

namespace ReserveAqui.Application.UseCases.Administrador.Deletar;
public class DeletarAdministradorValidator : AbstractValidator<DeletarAdministradorRequest>
{
    public DeletarAdministradorValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("O id não pode ser nulo");
    }
}
