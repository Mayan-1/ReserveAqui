using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;

namespace ReserveAqui.Application.UseCases.Instituicoes.ObterTodos;

public class ObterTodasInstituicoesHandler : IRequestHandler<ObterTodasInstituicoesRequest, ICollection<ObterTodasInstituicoesResponse>>
{
    private readonly IInstituicaoRepository _instituicaoRepository;
    private readonly IMapper _mapper;

    public ObterTodasInstituicoesHandler(IInstituicaoRepository instituicaoRepository, IMapper mapper)
    {
        _instituicaoRepository = instituicaoRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<ObterTodasInstituicoesResponse>> Handle(ObterTodasInstituicoesRequest request, CancellationToken cancellationToken)
    {
        var instituicoes = await _instituicaoRepository.ObterTodos(cancellationToken);

        if (instituicoes == null)
        {
            return null;
        }

        return _mapper.Map<ICollection<ObterTodasInstituicoesResponse>>(instituicoes);
    }
}
