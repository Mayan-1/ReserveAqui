namespace ReserveAqui.Application.UseCases.Material.ObterTodos;

public sealed record ObterTodosMateriaisResponse
{
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public string Tipo { get; set; } = string.Empty;

}