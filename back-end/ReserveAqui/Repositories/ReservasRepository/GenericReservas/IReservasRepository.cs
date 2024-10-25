namespace ReserveAqui.Repositories.ReservasRepository.GenericReservas;

public interface IReservasRepository<TEntity> where TEntity : class
{
    Task<bool> ExisteReserva(DateOnly data, string turno);
    Task<TEntity> GetReserva(int id);
    Task<IEnumerable<TEntity>> GetAllReserva();
}
