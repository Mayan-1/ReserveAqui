using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.SalaRepository;

public interface ISalaRepository : IBaseRepository<Sala>
{
    Task<Sala> ObterSalaPorNome(string nome);
}
