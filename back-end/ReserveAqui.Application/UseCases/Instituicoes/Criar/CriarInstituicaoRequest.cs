using MediatR;

namespace ReserveAqui.Application.UseCases.Instituicoes.Criar;

public sealed record CriarInstituicaoRequest(string Nome) : IRequest<CriarInstituicaoResponse>;

