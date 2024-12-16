using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;

namespace ReserveAqui.Infra.Config.Repositories.ReservaMaterialRepository;

public class ReservaMaterialRepository : BaseRepository<ReservaMaterial>, IReservaMaterialRepository
{
    public ReservaMaterialRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> ObterReservaPorData(DateOnly data, Turno turno, Material material, CancellationToken cancellationToken)
    {
        var reservaExiste = await Context.ReservaMaterial.AnyAsync(d => d.Data == data && d.Turno == turno && d.Material == material);
        return reservaExiste;
        
    }

    public async Task<ICollection<ReservaMaterial>> ObterReservasPorProfessor(int id, CancellationToken cancellationToken)
    {
        var reservas = await Context.ReservaMaterial
            .Include(s => s.Material)
            .Include(t => t.Turno)
            .Include(p => p.Professor)
            .Where(x => x.Professor.Id == id).ToListAsync();
        return reservas;
    }
}
