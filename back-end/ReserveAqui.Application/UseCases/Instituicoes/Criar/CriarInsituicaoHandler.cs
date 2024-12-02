using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Instituicoes.Criar;

public class CriarInsituicaoHandler : IRequestHandler<CriarInstituicaoRequest, CriarInstituicaoResponse>
{
    private readonly Mapper _mapper;
    private readonly IInstituicaoRepository _instituicaoRepository;
    private readonly IUnitOfWork _uof;

    public CriarInsituicaoHandler(Mapper mapper, IInstituicaoRepository instituicaoRepository, IUnitOfWork uof)
    {
        _mapper = mapper;
        _instituicaoRepository = instituicaoRepository;
        _uof = uof;
    }

    public async Task<CriarInstituicaoResponse> Handle(CriarInstituicaoRequest request, CancellationToken cancellationToken)
    {
        var instituicao = _mapper.Map<Instituicao>(request);

        _instituicaoRepository.Criar(instituicao);

        await _uof.Commit(cancellationToken);
        return new CriarInstituicaoResponse { Mensagem = "Instiuição criada com sucesso." };
    }
}
