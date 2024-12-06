using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;

namespace ReserveAqui.Application.UseCases.Instituicoes.Atualizar;

public class AtualizarInstituicaoHandler : IRequestHandler<AtualizarInstituicaoRequest, AtualizarInstituicaoResponse>
{
    private readonly IInstituicaoRepository _instituicaoRepository;
    private readonly IUnitOfWork _uof;

    public AtualizarInstituicaoHandler(IInstituicaoRepository instituicaoRepository, IUnitOfWork uof)
    {
        _instituicaoRepository = instituicaoRepository;
        _uof = uof;
    }

    public async Task<AtualizarInstituicaoResponse> Handle(AtualizarInstituicaoRequest request, CancellationToken cancellationToken)
    {
        var instituicao = await _instituicaoRepository.Obter(request.Id, cancellationToken);
        if (instituicao == null)
        {
            return new AtualizarInstituicaoResponse { Mensagem = "Instituição não localizada" };
        }

        instituicao.Nome = request.Nome;
        _instituicaoRepository.Atualizar(instituicao);
        await _uof.Commit(cancellationToken);
        return new AtualizarInstituicaoResponse { Mensagem = "Instituição atualizada com sucesso" };
    }
}
