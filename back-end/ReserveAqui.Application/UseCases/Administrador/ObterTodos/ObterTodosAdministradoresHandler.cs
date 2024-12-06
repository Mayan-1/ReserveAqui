
using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.AdministradorRepository;

namespace ReserveAqui.Application.UseCases.Administrador.ObterTodos;

public class ObterTodosAdministradoresHandler : IRequestHandler<ObterTodosAdministradoresRequest, ICollection<ObterTodosAdministradoresResponse>>
{
    private readonly IAdministradorRepository _administradorRepository;
    private readonly IMapper _mapper;

    public ObterTodosAdministradoresHandler(IAdministradorRepository administradorRepository, IMapper mapper)
    {
        _administradorRepository = administradorRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterTodosAdministradoresResponse>> Handle(ObterTodosAdministradoresRequest request, CancellationToken cancellationToken)
    {
        var administradores = await _administradorRepository.ObterTodos(cancellationToken);
        if (administradores == null)
            return null;

        return _mapper.Map<ICollection<ObterTodosAdministradoresResponse>>(administradores);
    }
}
