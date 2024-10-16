using ReserveAqui.Models;

namespace ReserveAqui.Repositories.MateriasRepository;

public interface IMateriaRepository : IRepository<Materia>
{
    Task<Materia> GetMateriaAsync(int id);
    Task<IEnumerable<Materia>> GetAllMateriasAsync();

}
