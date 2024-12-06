
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;

namespace ReserveAqui.Application.UseCases.Instituicoes.Deletar;

public class DeletarInstituicaoHandler : IRequestHandler<DeletarInstituicaoRequest, DeletarInstituicaoResponse>
{
    private readonly IInstituicaoRepository _instituicaoRepository;
    private readonly IUnitOfWork _uof;

    public DeletarInstituicaoHandler(IInstituicaoRepository instituicaoRepository, IUnitOfWork uof)
    {
        _instituicaoRepository = instituicaoRepository;
        _uof = uof;
    }

    public async Task<DeletarInstituicaoResponse> Handle(DeletarInstituicaoRequest request, CancellationToken cancellationToken)
    {
        var instituicao = await _instituicaoRepository.Obter(request.Id, cancellationToken);
        if (instituicao == null)
        {
            return new DeletarInstituicaoResponse { Mensagem = "Instituição não localizada"};
        }

        _instituicaoRepository.Deletar(instituicao);
        await _uof.Commit(cancellationToken);

        return new DeletarInstituicaoResponse { Mensagem = "Instituição deletada." };
    }
}
