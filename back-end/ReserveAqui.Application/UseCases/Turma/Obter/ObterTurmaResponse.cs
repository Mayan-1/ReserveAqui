using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Turma.Obter;

public sealed record ObterTurmaResponse
{
    public string Nome { get; set; } = string.Empty;
    public int QuantidadeAlunos { get; set; }
    public Turno? Turno { get; set; }
    public string Codigo { get; set; } = string.Empty;
}