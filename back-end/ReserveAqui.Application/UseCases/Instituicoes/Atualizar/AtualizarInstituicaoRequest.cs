using MediatR;

namespace ReserveAqui.Application.UseCases.Instituicoes.Atualizar;
public sealed record AtualizarInstituicaoRequest(int Id, string Nome) : IRequest<AtualizarInstituicaoResponse>;
