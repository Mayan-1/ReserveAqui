using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;

namespace ReserveAqui.Infra.Config.Repositories.TurnoRepository;

public class TurnoRepository : BaseRepository<Turno>, ITurnoRepository
{
    public TurnoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Turno> ObterPorNome(string nome)
    {
        var turno = await Context.Turno.FirstOrDefaultAsync(x => x.Nome == nome);
        if (turno == null) return null;
        return turno;
    }
}
