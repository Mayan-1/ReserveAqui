using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;

namespace ReserveAqui.Application.UseCases.Materias.Obter;

public class ObterMateriaHandler : IRequestHandler<ObterMateriaRequest, ObterMateriaResponse>
{
    private readonly IMateriaRepository _materiaRepository;

    public ObterMateriaHandler(IMateriaRepository materiaRepository)
    {
        _materiaRepository = materiaRepository;
    }

    public async Task<ObterMateriaResponse> Handle(ObterMateriaRequest request, CancellationToken cancellationToken)
    {
        var materia = await _materiaRepository.Obter(request.Id, cancellationToken);

        if (materia == null)
        {
            return null;
        }

        return new ObterMateriaResponse { Nome = materia.Nome };
    }
}
