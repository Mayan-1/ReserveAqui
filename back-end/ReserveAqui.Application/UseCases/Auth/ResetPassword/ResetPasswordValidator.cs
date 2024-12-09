using FluentValidation;

namespace ReserveAqui.Application.UseCases.Auth.ResetPassword;

public class ResetPasswordValidator : AbstractValidator<ResetPasswordRequest>
{
    public ResetPasswordValidator()
    {
        /// no validation
    }
}
