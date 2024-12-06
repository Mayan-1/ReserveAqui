using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;

namespace ReserveAqui.Application.UseCases.Professores.Obter;

public class ObterProfessorHandler : IRequestHandler<ObterProfessorRequest, ObterProfessorResponse>
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IMapper _mapper;

    public ObterProfessorHandler(IProfessorRepository professorRepository, IMapper mapper)
    {
        _professorRepository = professorRepository;
        _mapper = mapper;
    }

    public async Task<ObterProfessorResponse> Handle(ObterProfessorRequest request, CancellationToken cancellationToken)
    {
        var professor = await _professorRepository.ObterProfessor(request.Id, cancellationToken);
        if (professor == null)
        {
            return null;
        }

        return _mapper.Map<ObterProfessorResponse>(professor);
    }
}
