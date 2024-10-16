using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Models;

namespace ReserveAqui.Repositories.ProfessoresRepository;

public class ProfessorRepository : Repository<Professor>, IProfessorRepository
{
    public ProfessorRepository(AppDbContext context) : base(context)
    {}
    public async Task<IEnumerable<Professor>> GetAllProfessoresAsync()
    {
        var professores = await _context.Professor
            .Include(i => i.Instituicao)
            .Include(m => m.Materias)
            .AsNoTracking()
            .ToListAsync();
        return professores;
    }

    public async Task<Professor> GetProfessorAsync(int id)
    {
        var professor = await _context.Professor
            .Include(i => i.Instituicao)
            .Include(m => m.Materias)
            .FirstOrDefaultAsync(x => x.Id == id);
        return professor;
    }

    public AppDbContext AppDbContext
    {
        get { return _context; }
    }
}
