namespace ReserveAqui.Application.UseCases.Instituicoes.Obter;

public sealed record ObterInstituicaoResponse
{
    public string Nome { get; set; } = string.Empty;
}