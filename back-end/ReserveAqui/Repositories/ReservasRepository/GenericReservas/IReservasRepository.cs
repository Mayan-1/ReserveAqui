namespace ReserveAqui.Repositories.ReservasRepository.GenericReservas;

public interface IReservasRepository<TEntity> where TEntity : class
{
    //Task<bool> ExisteReserva(DateTime inicio, DateTime fim);
    Task<TEntity> GetReserva(int id);
    Task<IEnumerable<TEntity>> GetAllReserva();
}
