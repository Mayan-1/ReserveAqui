namespace ReserveAqui.Application.UseCases.Auth.ForgotPassword;

public sealed record ForgotPasswordResponse
{
    public string Message { get; set; } = string.Empty;
}