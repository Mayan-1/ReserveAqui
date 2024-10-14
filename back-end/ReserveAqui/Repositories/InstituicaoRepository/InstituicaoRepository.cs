using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Models;

namespace ReserveAqui.Repositories.InstituicaoRepository;

public class InstituicaoRepository : Repository<Instituicao>, IInstituicaoRepository
{
    public InstituicaoRepository(AppDbContext context) : base(context)
    {}

    public async Task<Instituicao> GetInstituicaoAsync(int id)
    {
        var instituicao = await _context.Instituicao
            .Include(a => a.Administradores)
            .Include(p => p.Professores)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        return instituicao;
    }

    public async Task<IEnumerable<Instituicao>> GetInstituicoesAsync()
    {
        var instituicoes = await _context.Instituicao
            .Include(a => a.Administradores)
            .Include(p => p.Professores)
            .ToListAsync();
        return instituicoes;
    }
    public AppDbContext AppDbContext
    {
        get { return _context; }
    }
}
