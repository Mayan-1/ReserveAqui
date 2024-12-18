using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.TurmaRepository;

public interface ITurmaRepository : IBaseRepository<Turma>
{
    Task<ICollection<Turma>> ObterTodasTurmas();
    Task<Turma> ObterTurma(int id);
}
