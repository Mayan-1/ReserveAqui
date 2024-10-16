using ReserveAqui.Config;
using ReserveAqui.Models;

namespace ReserveAqui.Repositories.SalasRepository;

public class SalaRepository : Repository<Sala>, ISalaRepository
{
	public SalaRepository(AppDbContext context) : base(context)	
	{}

	public AppDbContext AppDbContext
	{
		get { return _context; }
	}
}
