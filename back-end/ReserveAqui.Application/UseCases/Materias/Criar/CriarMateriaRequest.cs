using MediatR;

namespace ReserveAqui.Application.UseCases.Materias.Criar
{
    public record CriaMateriaRequest(string Nome) : IRequest<CriarMateriaResponse>;
}
