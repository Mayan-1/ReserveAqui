using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;

namespace ReserveAqui.Application.UseCases.Sala.Criar;

public class CriarSalaHandler : IRequestHandler<CriarSalaRequest, CriarSalaResponse>
{
    private readonly ISalaRepository _salaRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    public CriarSalaHandler(ISalaRepository salaRepository, IUnitOfWork uof, IMapper mapper)
    {
        _salaRepository = salaRepository;
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<CriarSalaResponse> Handle(CriarSalaRequest request, CancellationToken cancellationToken)
    {
        var sala = _mapper.Map<Core.Models.Sala>(request);

        _salaRepository.Criar(sala);
        await _uof.Commit(cancellationToken);
        return new CriarSalaResponse { Mensagem = "Sala adicionada com sucesso" };
    }
}
