using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Materias.Criar;

public class CriarMateriaHandler : IRequestHandler<CriaMateriaRequest, CriarMateriaResponse>
{
    private readonly IMateriaRepository _materiaRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uof;

    public CriarMateriaHandler(IMateriaRepository materiaRepository, IMapper mapper, IUnitOfWork uof)
    {
        _materiaRepository = materiaRepository;
        _mapper = mapper;
        _uof = uof;
    }

    public async Task<CriarMateriaResponse> Handle(CriaMateriaRequest request, CancellationToken cancellationToken)
    {
        var materia = _mapper.Map<Materia>(request);

        _materiaRepository.Criar(materia);

        await _uof.Commit(cancellationToken);
        return new CriarMateriaResponse { Mensagem = "Matéria adicionada com sucesso" };
    }
}
