using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;

namespace ReserveAqui.Infra.Config.Repositories.MaterialRepository;

public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
{
    public MaterialRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Material> ObterMaterialPorNome(string nome)
    {
        var material = await Context.Material.FirstOrDefaultAsync(x = x => x.Nome == nome);
        return material;    
    }
}
