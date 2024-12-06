using FluentValidation;

namespace ReserveAqui.Application.UseCases.Administrador.Obter;

public class ObterAdministradorValidator : AbstractValidator<ObterAdministradorRequest>
{
    public ObterAdministradorValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
