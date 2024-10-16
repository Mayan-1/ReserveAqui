using ReserveAqui.Config;
using ReserveAqui.Models;

namespace ReserveAqui.Repositories.MateriaisRepository;

public class MaterialRepository : Repository<Material>, IMaterialRepository
{
    public MaterialRepository(AppDbContext context) : base(context)
    {}

    public AppDbContext Context
    {
        get { return _context; }
    }
}
