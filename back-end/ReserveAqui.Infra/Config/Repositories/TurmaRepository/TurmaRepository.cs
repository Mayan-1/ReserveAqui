using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Interfaces.Repositories.TurmaRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;

namespace ReserveAqui.Infra.Config.Repositories.TurmaRepository;

public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
{
    public TurmaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Turma> ObterTurma(int id)
    {
        var turma = await Context.Turma.Include(t => t.Turno).FirstOrDefaultAsync(x => x.Id == id);
        return turma;
    }

    public async Task<ICollection<Turma>> ObterTodasTurmas()
    {
        var turmas = await Context.Turma.Include(t => t.Turno).ToListAsync();
        return turmas;
    }
}
