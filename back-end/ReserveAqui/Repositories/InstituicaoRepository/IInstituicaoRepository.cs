using ReserveAqui.Models;

namespace ReserveAqui.Repositories.InstituicaoRepository;

public interface IInstituicaoRepository : IRepository<Instituicao>
{
    Task<Instituicao> GetInstituicaoAsync(int id);
    Task<IEnumerable<Instituicao>> GetInstituicoesAsync();
}
