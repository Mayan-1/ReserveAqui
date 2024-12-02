using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;

public interface IReservaSalaRepository : IBaseRepository<ReservaSala>
{
    Task<ReservaSala> ObterReservaPorData(DateOnly data, CancellationToken cancellationToken);
}
