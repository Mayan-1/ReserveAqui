
using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;

namespace ReserveAqui.Application.UseCases.Instituicoes.Obter;

public class ObterInstituicaoHandler : IRequestHandler<ObterInstituicaoRequest, ObterInstituicaoResponse>
{
    private readonly IInstituicaoRepository _instituicaoRepository;
    private readonly IMapper _mapper;

    public ObterInstituicaoHandler(IInstituicaoRepository instituicaoRepository, IMapper mapper)
    {
        _instituicaoRepository = instituicaoRepository;
        _mapper = mapper;
    }

    public async Task<ObterInstituicaoResponse> Handle(ObterInstituicaoRequest request, CancellationToken cancellationToken)
    {
        var instituicao = await _instituicaoRepository.Obter(request.Id, cancellationToken);
        if (instituicao == null)
        {
            return null;
        }

        return _mapper.Map<ObterInstituicaoResponse>(instituicao);

    }
}
