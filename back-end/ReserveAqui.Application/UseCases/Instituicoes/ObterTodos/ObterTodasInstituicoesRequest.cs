using MediatR;

namespace ReserveAqui.Application.UseCases.Instituicoes.ObterTodos;

public sealed record ObterTodasInstituicoesRequest : IRequest<ICollection<ObterTodasInstituicoesResponse>>;

