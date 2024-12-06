using MediatR;

namespace ReserveAqui.Application.UseCases.Professores.Atualizar;

public sealed record AtualizarProfessorRequest(int Id, string Nome,string Email,
                                               string Cpf,string Telefone, 
                                               string Materia, string Instituicao) : IRequest<AtualizarProfessorResponse>;
