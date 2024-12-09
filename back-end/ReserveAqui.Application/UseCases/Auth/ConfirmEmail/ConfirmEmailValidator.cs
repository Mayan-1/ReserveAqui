﻿using FluentValidation;

namespace ReserveAqui.Application.UseCases.Auth.ConfirmEmail
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailRequest>
    {
        public ConfirmEmailValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}
