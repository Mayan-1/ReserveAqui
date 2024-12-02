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

    public async Task<ReservaSala> ObterReservaPorData(DateOnly data, CancellationToken cancellationToken)
    {
        var reserva = await Context.ReservaSala.FirstOrDefaultAsync(d => d.Data == data);
        return reserva;
    }
}
