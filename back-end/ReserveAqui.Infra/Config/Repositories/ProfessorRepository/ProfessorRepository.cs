using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveAqui.Infra.Config.Repositories.ProfessorRepository;

public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
{
    public ProfessorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<ICollection<Professor>> ObterProfessores(CancellationToken cancellationToken)
    {
        var professores = await Context.Professor
            .Include(x => x.Materia)
            .Include(x => x.Instituicao)
            .ToListAsync();
        return professores;
    }

    public async Task<Professor> ObterProfessor(int id, CancellationToken cancellationToken)
    {
        var professores = await Context.Professor
            .Include(x => x.Materia)
            .Include(x => x.Instituicao)
            .FirstOrDefaultAsync(x => x.Id == id);
        return professores;
    }

    public async Task<Professor> ObterProfessorPorNome(string nome)
    {
        var professor = await Context.Professor
            .Include(x => x.Materia)
            .Include(x => x.Instituicao)
            .FirstOrDefaultAsync(x => x.Nome == nome);
        return professor;
    }
}
