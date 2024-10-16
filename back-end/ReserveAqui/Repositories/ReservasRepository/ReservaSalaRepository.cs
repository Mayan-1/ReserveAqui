using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Models;

namespace ReserveAqui.Repositories.ReservasRepository;

public class ReservaSalaRepository : Repository<ReservaSala>, IReservaSalaRepository
{
    public ReservaSalaRepository(AppDbContext context) : base(context)
    {}
    public async Task<bool> ExisteReserva(DateTime inicio, DateTime fim)
    {
        return await _context.ReservaSala
            .AnyAsync(r => (r.HoraInicio < fim && r.HoraFim > inicio));
    }

    public async Task<IEnumerable<ReservaSala>> GetAllReserva()
    {
        var reservas = await _context.ReservaSala
            .Include(s => s.Sala)
            .Include(p => p.Professor)
            .ToListAsync();
        return reservas;
    }   

    public async Task<ReservaSala> GetReserva(int id)
    {
        var reserva = await _context.ReservaSala
            .Include(s => s.Sala)
            .Include(p => p.Professor)
            .FirstOrDefaultAsync(x => x.Id == id);
        return reserva;
    }

    public AppDbContext AppDbContext
    {
        get { return _context; }
    }
}
