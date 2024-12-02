using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Common;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Infra.Config.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveAqui.Infra.Config.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext Context;

    public BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    public void Criar(TEntity entity)
    {
        entity.DataCriacao = DateTimeOffset.UtcNow;
        Context.Add(entity);
    }

    public void Deletar(TEntity entity)
    {
        entity.DataExclusao = DateTimeOffset.UtcNow;
        Context.Remove(entity);
    }

    public async Task<TEntity> Obter(int id, CancellationToken cancellationToken)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<ICollection<TEntity>> ObterTodos(CancellationToken cancellationToken)
    {
        return await Context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public void Atualizar(TEntity entity)
    {
        entity.DataModificacao = DateTimeOffset.UtcNow;
        Context.Update(entity);
    }

}
