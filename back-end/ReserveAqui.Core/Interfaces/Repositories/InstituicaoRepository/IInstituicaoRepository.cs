using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;

public interface IInstituicaoRepository : IBaseRepository<Instituicao>
{
    Task<Instituicao> ObterPorNome(string nome);
}
