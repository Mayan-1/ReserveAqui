using MediatR;

namespace ReserveAqui.Application.UseCases.Materias.Atualizar;

public sealed record AtualizarMateriaRequest(int Id, string Nome) : IRequest<AtualizarMateriaResponse>;
