namespace ReserveAqui.Application.UseCases.Sala.Obter;

public sealed record ObterSalaResponse
{
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public int Capacidade { get; set; }
}