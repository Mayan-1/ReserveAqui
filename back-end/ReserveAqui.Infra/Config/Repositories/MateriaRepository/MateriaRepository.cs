using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;

namespace ReserveAqui.Infra.Config.Repositories.MateriaRepository;

public class MateriaRepository : BaseRepository<Materia>, IMateriaRepository
{
    public MateriaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Materia> ObterMateria(int id)
    {
        var materia = await Context.Materia.Include(p => p.Professores).FirstOrDefaultAsync(x => x.Id == id);
        return materia;
    }

    public async Task<Materia> ObterPorNome(string nome)
    {
        var materia = await Context.Materia.FirstOrDefaultAsync(x => x.Nome == nome);
        return materia;
    }

    public async Task<ICollection<Materia>> ObterTodasMaterias()
    {
        var materias = await Context.Materia.Include(p => p.Professores).ToListAsync();
        return materias;
    }
}
