using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Models;

namespace ReserveAqui.Repositories.MateriasRepository;

public class MateriaRepository : Repository<Materia>, IMateriaRepository
{
    public MateriaRepository(AppDbContext context) : base(context)
    {}

    public async Task<IEnumerable<Materia>> GetAllMateriasAsync()
    {
        var materias = await _context.Materia
            .Include(p => p.Professores)
            .AsNoTracking()
            .ToListAsync();
        return materias;
    }

    public async Task<Materia> GetMateriaAsync(int id)
    {
        var materia = await _context.Materia
            .Include(p => p.Professores)
            .FirstOrDefaultAsync(x => x.Id == id);
        return materia;
    }

    public AppDbContext AppDbContext
    {
        get { return _context; }
    }
}
