﻿using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;

public interface IReservaMaterialRepository : IBaseRepository<ReservaMaterial>
{
    Task<bool> ObterReservaPorData(DateOnly data, Turno turno, Material material, CancellationToken cancellationToken);

}
