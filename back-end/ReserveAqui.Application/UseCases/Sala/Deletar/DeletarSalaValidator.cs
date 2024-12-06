using FluentValidation;

namespace ReserveAqui.Application.UseCases.Sala.Deletar;

public class DeletarSalaValidator : AbstractValidator<DeletarSalaRequest>
{
    public DeletarSalaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
