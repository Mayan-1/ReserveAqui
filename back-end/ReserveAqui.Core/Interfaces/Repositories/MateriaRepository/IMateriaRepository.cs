using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;

public interface IMateriaRepository : IBaseRepository<Materia>
{
    Task<Materia> ObterPorNome(string nome);
    Task<ICollection<Materia>> ObterTodasMaterias();
    Task<Materia> ObterMateria(int id);

}
