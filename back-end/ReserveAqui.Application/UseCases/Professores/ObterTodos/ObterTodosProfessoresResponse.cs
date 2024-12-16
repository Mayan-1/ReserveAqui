using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Professores.ObterTodos;

public sealed record ObterTodosProfessoresResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public Materia Materia { get; set; }
    public Instituicao Instituicao { get; set; }
}