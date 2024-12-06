using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;

namespace ReserveAqui.Application.UseCases.Material.Obter;

public class ObterMaterialHandler : IRequestHandler<ObterMaterialRequest, ObterMaterialResponse>
{
    private readonly IMaterialRepository _materialRepository;
    private readonly IMapper _mapper;
    public ObterMaterialHandler(IMaterialRepository materialRepository, IMapper mapper)
    {
        _materialRepository = materialRepository;
        _mapper = mapper;
    }

    public async Task<ObterMaterialResponse> Handle(ObterMaterialRequest request, CancellationToken cancellationToken)
    {
        var material = await _materialRepository.Obter(request.Id, cancellationToken);

        if (material == null)
            return null;

        return _mapper.Map<ObterMaterialResponse>(material);
    }
}
