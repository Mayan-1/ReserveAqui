using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;

namespace ReserveAqui.Application.UseCases.Material.ObterTodos;

public class ObterTodosMateriaisHandler : IRequestHandler<ObterTodosMateriaisRequest, ICollection<ObterTodosMateriaisResponse>>
{
    private readonly IMaterialRepository _materialRepository;
    private readonly IMapper _mapper;

    public ObterTodosMateriaisHandler(IMaterialRepository materialRepository, IMapper mapper)
    {
        _materialRepository = materialRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterTodosMateriaisResponse>> Handle(ObterTodosMateriaisRequest request, CancellationToken cancellationToken)
    {
        var materiais = await _materialRepository.ObterTodos(cancellationToken);
        if (materiais == null)
            return null;

        return _mapper.Map<ICollection<ObterTodosMateriaisResponse>>(materiais);
    }
}
