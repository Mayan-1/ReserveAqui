using MediatR;

namespace ReserveAqui.Application.UseCases.Instituicoes.Obter;

public sealed record ObterInstituicaoRequest(int Id) : IRequest<ObterInstituicaoResponse>
{
}
