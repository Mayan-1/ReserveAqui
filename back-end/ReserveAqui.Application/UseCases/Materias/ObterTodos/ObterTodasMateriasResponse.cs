using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Materias.ObterTodos;

public sealed record ObterTodasMateriasResponse
{
    public string Nome { get; set; } = string.Empty;
}