using ReserveAqui.Models;

namespace ReserveAqui.Repositories.ProfessoresRepository;

public interface IProfessorRepository : IRepository<Professor>
{
    Task<Professor> GetProfessorAsync(int id);
    Task<IEnumerable<Professor>> GetAllProfessoresAsync();
}
