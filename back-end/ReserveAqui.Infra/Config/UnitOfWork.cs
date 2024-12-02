using ReserveAqui.Core.Interfaces;
using ReserveAqui.Infra.Config.Data;

namespace ReserveAqui.Infra.Config;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
