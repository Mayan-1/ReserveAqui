using Microsoft.EntityFrameworkCore;
using ReserveAqui.Config;
using ReserveAqui.Models;

namespace ReserveAqui.Repositories.AdministradoresRepository;

public class AdministradorRepository : Repository<Administrador>, IAdministradorRepository
{
    public AdministradorRepository(AppDbContext context) : base(context)
    {}

    public async Task<Administrador> GetAdministradorAsync(int id)
    {
        var administrador = await _context.Administrador
            .Include(i => i.Instituicao)
            .FirstOrDefaultAsync(x => x.Id == id);
        return administrador;
    }

    public async Task<IEnumerable<Administrador>> GetAllAdministradoresAsync()
    {
        var administradores = await _context.Administrador
            .Include(i => i.Instituicao)
            .ToListAsync();
        return administradores;
    }

    public AppDbContext AppDbContext
    {
        get { return _context; }
    }
}
