using ReserveAqui.Models;
using ReserveAqui.Repositories.ReservasRepository.GenericReservas;

namespace ReserveAqui.Repositories.ReservasRepository;

public interface IReservaSalaRepository : IRepository<ReservaSala>, IReservasRepository<ReservaSala>
{}
