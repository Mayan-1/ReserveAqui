using ReserveAqui.Models;
using ReserveAqui.Repositories.ReservasRepository.GenericReservas;

namespace ReserveAqui.Repositories.ReservasRepository;

public interface IReservaMaterialRepository : IRepository<ReservaMaterial>, IReservasRepository<ReservaMaterial>
{}
