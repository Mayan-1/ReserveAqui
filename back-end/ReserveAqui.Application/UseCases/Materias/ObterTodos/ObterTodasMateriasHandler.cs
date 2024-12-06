using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;

namespace ReserveAqui.Application.UseCases.Materias.ObterTodos;

public class ObterTodasMateriasHandler : IRequestHandler<ObterTodasMateriasRequest, ICollection<ObterTodasMateriasResponse>>
{
    private readonly IMateriaRepository _materiaRepository;
    private readonly IMapper _mapper;

    public ObterTodasMateriasHandler(IMateriaRepository materiaRepository, IMapper mapper)
    {
        _materiaRepository = materiaRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterTodasMateriasResponse>> Handle(ObterTodasMateriasRequest request, CancellationToken cancellationToken)
    {
        var materias = await _materiaRepository.ObterTodos(cancellationToken);

        return _mapper.Map<ICollection<ObterTodasMateriasResponse>>(materias);

    }
}
