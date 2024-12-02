using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;

namespace ReserveAqui.Infra.Config.Repositories.SalaRepository;

public class SalaRepository : BaseRepository<Sala>, ISalaRepository
{
    public SalaRepository(AppDbContext context) : base(context)
    {
    }
}
