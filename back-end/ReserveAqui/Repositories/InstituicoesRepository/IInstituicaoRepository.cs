using ReserveAqui.Models;

namespace ReserveAqui.Repositories.InstituicoesRepository;

public interface IInstituicaoRepository : IRepository<Instituicao>
{
    Task<Instituicao> GetInstituicaoAsync(int id);
    Task<IEnumerable<Instituicao>> GetInstituicoesAsync();
}
