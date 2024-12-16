using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;

namespace ReserveAqui.Infra.Config.Repositories.ReservaSalaRepository;

public class ReservaSalaRepository : BaseRepository<ReservaSala>, IReservaSalaRepository
{
    public ReservaSalaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<ICollection<ReservaSala>> ObterReservasPorProfessor(int id, CancellationToken cancellationToken)
    {
        var reservas = await Context.ReservaSala
            .Include(s => s.Sala)
            .Include(t => t.Turno)
            .Include(p => p.Professor)
            .Where(x => x.Professor.Id == id).ToListAsync();
        return reservas;
    }

    public async Task<bool> ObterReservaPorData(DateOnly data, Turno turno, Sala sala, CancellationToken cancellationToken)
    {
        var reservaExiste = await Context.ReservaSala.AnyAsync(d => d.Data == data && d.Turno == turno && d.Sala == sala);
        return reservaExiste;
    }

    public async Task<ICollection<ReservaSala>> ObterReservasComFiltro(Sala sala, Turno turno, CancellationToken cancellationToken)
    {
        var reservas = await Context.ReservaSala.Where(x => x.Turno == turno && x.Sala == sala).ToListAsync();
        return reservas;
    }
}
