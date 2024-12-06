using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;

namespace ReserveAqui.Application.UseCases.Materias.Atualizar;

public class AtualizarMateriaHandler : IRequestHandler<AtualizarMateriaRequest, AtualizarMateriaResponse>
{
    private readonly IMateriaRepository _materiaRepository;
    private readonly IUnitOfWork _uof;

    public AtualizarMateriaHandler(IMateriaRepository materiaRepository, IUnitOfWork uof)
    {
        _materiaRepository = materiaRepository;
        _uof = uof;
    }

    public async Task<AtualizarMateriaResponse> Handle(AtualizarMateriaRequest request, CancellationToken cancellationToken)
    {
        var materia = await _materiaRepository.Obter(request.Id, cancellationToken);
        if (materia == null)
        {
            return new AtualizarMateriaResponse { Mensagem = "Matéria não encontrada" };
        }

        materia.Nome = request.Nome;

        _materiaRepository.Atualizar(materia);
        await _uof.Commit(cancellationToken);
        return new AtualizarMateriaResponse { Mensagem = "Matéria atualizada com sucesso" };
    }
}
