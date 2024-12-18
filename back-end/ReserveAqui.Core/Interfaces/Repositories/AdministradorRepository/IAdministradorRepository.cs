using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.AdministradorRepository;

public interface IAdministradorRepository : IBaseRepository<Administrador>
{
    Task<Administrador> ObterAdministradorPorNome(string nome);
}
