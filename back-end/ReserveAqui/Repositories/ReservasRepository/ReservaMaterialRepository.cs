﻿using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Models;

namespace ReserveAqui.Repositories.ReservasRepository;

public class ReservaMaterialRepository : Repository<ReservaMaterial>, IReservaMaterialRepository
{
    public ReservaMaterialRepository(AppDbContext context) : base(context) 
    {}
    public async Task<bool> ExisteReserva(DateOnly data, Turno turno)
    {
        return await _context.ReservaMaterial
                .AnyAsync(r => (r.Turno == turno && r.Data == data));
        
    }

    public async Task<IEnumerable<ReservaMaterial>> GetAllReserva()
    {
        var reservas = await _context.ReservaMaterial
            .Include(m => m.Material)
            .Include(p => p.Professor)
            .ToListAsync();
        return reservas;
    }

    public async Task<ReservaMaterial> GetReserva(int id)
    {
        var reserva = await _context.ReservaMaterial
            .Include(m => m.Material)
            .Include(p => p.Professor)
            .FirstOrDefaultAsync(x => x.Id == id);
        return reserva;
    }

    public AppDbContext AppDbContext
    {
        get { return _context; }
    }
}
