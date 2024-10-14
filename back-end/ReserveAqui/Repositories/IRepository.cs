using System.Linq.Expressions;

namespace ReserveAqui.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    // Metódos de busca
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetAsync(int id);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);

    // Metódo de criação
    Task<TEntity?> AddAsync(TEntity entity);

    // Metódo de exclusão
    Task<TEntity?> RemoveAsync(TEntity entity);

    // Metódo de atualização
    Task<TEntity?> UpdateAsync(TEntity entity);


}
