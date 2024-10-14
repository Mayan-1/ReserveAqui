using ReserveAqui.Config;
using ReserveAqui.Models;

namespace ReserveAqui.Repositories.MaterialRepository;

public class MaterialRepository : Repository<Material>, IMaterialRepository
{
    public MaterialRepository(AppDbContext context) : base(context)
    {}

    public AppDbContext Context
    {
        get { return _context; }
    }
}
