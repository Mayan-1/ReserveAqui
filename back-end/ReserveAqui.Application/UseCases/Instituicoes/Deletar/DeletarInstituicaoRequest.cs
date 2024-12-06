
using MediatR;

namespace ReserveAqui.Application.UseCases.Instituicoes.Deletar;
public sealed record DeletarInstituicaoRequest(int Id) : IRequest<DeletarInstituicaoResponse>;
