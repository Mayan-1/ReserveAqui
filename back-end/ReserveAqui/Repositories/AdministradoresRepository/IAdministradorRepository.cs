using ReserveAqui.Models;

namespace ReserveAqui.Repositories.AdministradoresRepository;

public interface IAdministradorRepository : IRepository<Administrador>
{
    Task<Administrador> GetAdministradorAsync(int id);
    Task<IEnumerable<Administrador>> GetAllAdministradoresAsync();
}
