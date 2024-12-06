using MediatR;

namespace ReserveAqui.Application.UseCases.Materias.Obter;

public sealed record ObterMateriaRequest(int Id) : IRequest<ObterMateriaResponse>;
