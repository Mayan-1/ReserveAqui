using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;

namespace ReserveAqui.Application.UseCases.Professores.ObterTodos;

public class ObterTodosProfessoresHandler : IRequestHandler<ObterTodosProfessoresRequest, ICollection<ObterTodosProfessoresResponse>>
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IMapper _mapper;

    public ObterTodosProfessoresHandler(IProfessorRepository professorRepository, IMapper mapper)
    {
        _professorRepository = professorRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterTodosProfessoresResponse>> Handle(ObterTodosProfessoresRequest request, CancellationToken cancellationToken)
    {
        var professores = await _professorRepository.ObterProfessores(cancellationToken);

        if (professores == null)
        {
            return null;
        }


        return _mapper.Map<ICollection<ObterTodosProfessoresResponse>>(professores);

    }
}
