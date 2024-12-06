using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;

namespace ReserveAqui.Application.UseCases.Material.Criar;

public class CriarMaterialHandler : IRequestHandler<CriarMaterialRequest, CriarMaterialResponse>
{
    private readonly IMaterialRepository _materialRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    public CriarMaterialHandler(IMaterialRepository materialRepository, IUnitOfWork uof, IMapper mapper)
    {
        _materialRepository = materialRepository;
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<CriarMaterialResponse> Handle(CriarMaterialRequest request, CancellationToken cancellationToken)
    {
        var material = _mapper.Map<Core.Models.Material>(request);

        _materialRepository.Criar(material);
        await _uof.Commit(cancellationToken);

        return new CriarMaterialResponse { Mensagem = "Material criado com sucesso" };

    }
}
