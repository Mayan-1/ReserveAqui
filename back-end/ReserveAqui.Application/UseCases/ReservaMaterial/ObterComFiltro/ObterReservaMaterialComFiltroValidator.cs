using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.ObterComFiltro
{
    public class ObterReservaMaterialComFiltroValidator : AbstractValidator<ObterReservaMaterialComFiltroRequest>
    {
        public ObterReservaMaterialComFiltroValidator()
        {
            // no validation
        }
    }
}
