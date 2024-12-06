namespace ReserveAqui.Application.UseCases.Material.Obter;

public sealed record ObterMaterialResponse
{
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public string Tipo { get; set; } = string.Empty;

}