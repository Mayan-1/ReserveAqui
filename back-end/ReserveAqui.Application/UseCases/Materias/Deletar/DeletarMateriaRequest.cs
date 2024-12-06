using MediatR;

namespace ReserveAqui.Application.UseCases.Materias.Deletar;

public sealed record DeletarMateriaRequest(int Id) : IRequest<DeletarMateriaResponse>;
