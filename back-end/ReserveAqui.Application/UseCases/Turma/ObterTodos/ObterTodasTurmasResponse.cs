namespace ReserveAqui.Application.UseCases.Turma.ObterTodos;

public sealed record ObterTodasTurmasResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int QuantidadeAlunos { get; set; }
    public Core.Models.Turno? Turno { get; set; }
    public string Codigo { get; set; } = string.Empty;
}