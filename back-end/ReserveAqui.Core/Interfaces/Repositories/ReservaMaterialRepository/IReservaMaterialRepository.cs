using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;

public interface IReservaMaterialRepository : IBaseRepository<ReservaMaterial>
{
    Task<ReservaMaterial> ObterReservaPorData(DateOnly data, CancellationToken cancellationToken);

}
