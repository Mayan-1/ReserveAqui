using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;

public interface IReservaSalaRepository : IBaseRepository<ReservaSala>
{
    Task<bool> ObterReservaPorData(DateOnly data, Turno turno, Sala sala, CancellationToken cancellationToken);
    Task<ICollection<ReservaSala>> ObterReservasPorProfessor(int id, CancellationToken cancellationToken);

    Task<ICollection<ReservaSala>> ObterReservasComFiltro(Sala sala, Turno turno, CancellationToken cancellationToken);
}
