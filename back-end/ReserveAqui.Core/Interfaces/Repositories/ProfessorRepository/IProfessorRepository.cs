using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;

public interface IProfessorRepository : IBaseRepository<Professor>
{
    Task<Professor> ObterProfessor(int id, CancellationToken cancellationToken);
    Task<ICollection<Professor>> ObterProfessores(CancellationToken cancellationToken);
    Task<Professor> ObterProfessorPorNome(string nome);
}
