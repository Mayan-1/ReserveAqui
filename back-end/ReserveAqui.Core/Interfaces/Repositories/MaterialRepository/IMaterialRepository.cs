using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;

public interface IMaterialRepository : IBaseRepository<Material>
{
    Task<Material> ObterMaterialPorNome(string nome);
}
