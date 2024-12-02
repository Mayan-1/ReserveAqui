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

    public async Task<ReservaMaterial> ObterReservaPorData(DateOnly data, CancellationToken cancellationToken)
    {
        var reserva = await Context.ReservaMaterial.FirstOrDefaultAsync(d => d.Data == data);
        return reserva;
    }
}
