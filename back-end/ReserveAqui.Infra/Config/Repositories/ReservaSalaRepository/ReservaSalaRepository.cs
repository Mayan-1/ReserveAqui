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

    public async Task<bool> ObterReservaPorData(DateOnly data, Turno turno, Sala sala, CancellationToken cancellationToken)
    {
        var reservaExiste = await Context.ReservaSala.AnyAsync(d => d.Data == data && d.Turno == turno && d.Sala == sala);
        return reservaExiste;
    }

    
}
