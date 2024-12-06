using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveAqui.Application.UseCases.Instituicoes.ObterTodos;

public sealed class ObterTodasInstituicoesValidator : AbstractValidator<ObterTodasInstituicoesRequest>
{
    public ObterTodasInstituicoesValidator()
    {
        // no validation
    }
}
