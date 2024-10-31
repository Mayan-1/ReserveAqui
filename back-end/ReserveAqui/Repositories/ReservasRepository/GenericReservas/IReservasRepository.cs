using ReserveAqui.Models;

namespace ReserveAqui.Repositories.ReservasRepository.GenericReservas;

public interface IReservasRepository<TEntity> where TEntity : class
{
    Task<bool> ExisteReserva(DateOnly data, Turno turno);
    Task<TEntity> GetReserva(int id);
    Task<IEnumerable<TEntity>> GetAllReserva();
}
