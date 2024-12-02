using ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;

namespace ReserveAqui.Infra.Config.Repositories.MateriaRepository;

public class MateriaRepository : BaseRepository<Materia>, IMateriaRepository
{
    public MateriaRepository(AppDbContext context) : base(context)
    {
    }
}
