using ReserveAqui.Core.Common;

namespace ReserveAqui.Core.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    void Criar(TEntity entity);
    void Atualizar(TEntity entity);
    void Deletar(TEntity entity);
    Task<TEntity> Obter(int id, CancellationToken cancellationToken);
    Task<ICollection<TEntity>> ObterTodos(CancellationToken cancellationToken);
}
