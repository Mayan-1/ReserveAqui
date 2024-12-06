using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.AdministradorRepository;


namespace ReserveAqui.Application.UseCases.Administrador.Obter;

public class ObterAdministradorHandler : IRequestHandler<ObterAdministradorRequest, ObterAdministradorResponse>
{
    private readonly IAdministradorRepository _administradorRepository;
    private readonly IMapper _mapper;

    public ObterAdministradorHandler(IAdministradorRepository administradorRepository, IMapper mapper)
    {
        _administradorRepository = administradorRepository;
        _mapper = mapper;
    }

    public async Task<ObterAdministradorResponse> Handle(ObterAdministradorRequest request, CancellationToken cancellationToken)
    {
        var administrador = await _administradorRepository.Obter(request.Id, cancellationToken);

        if (administrador == null)
        {
            return null;
        }

        return _mapper.Map<ObterAdministradorResponse>(administrador);

    }
}
