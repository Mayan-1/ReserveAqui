using MediatR;
using ReserveAqui.Application.UseCases.Professores.Deletar;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;

namespace ReserveAqui.Application.UseCases.Materias.Deletar;
public class DeletarMateriaHandler : IRequestHandler<DeletarMateriaRequest, DeletarMateriaResponse>
{
    private readonly IMateriaRepository _materiaRepository;
    private readonly IUnitOfWork _uof;

    public DeletarMateriaHandler(IMateriaRepository materiaRepository, IUnitOfWork uof)
    {
        _materiaRepository = materiaRepository;
        _uof = uof;
    }

    public async Task<DeletarMateriaResponse> Handle(DeletarMateriaRequest request, CancellationToken cancellationToken)
    {
        var materia = await _materiaRepository.Obter(request.Id, cancellationToken);
        if (materia == null)
        {
            return new DeletarMateriaResponse { Mensagem ="Matéria não encotrada"};
        }

        _materiaRepository.Deletar(materia);
        await _uof.Commit(cancellationToken);
        return new DeletarMateriaResponse { Mensagem = "Matéria deletada com sucesso" };
    }
}
