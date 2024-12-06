using MediatR;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Professores.Criar
{
    public sealed record CriarProfessorRequest(string Nome, string Cpf, string Email, 
        string Senha, string Telefone, string Materia, string Instituicao) : IRequest<CriarProfessorResponse>;
    
    
}
