using ReserveAqui.Repositories.AdministradoresRepository;
using ReserveAqui.Repositories.InstituicoesRepository;
using ReserveAqui.Repositories.MateriaisRepository;
using ReserveAqui.Repositories.MateriasRepository;
using ReserveAqui.Repositories.ProfessoresRepository;
using ReserveAqui.Repositories.ReservasRepository;
using ReserveAqui.Repositories.SalasRepository;

namespace ReserveAqui.Repositories;

public interface IUnitOfWork : IDisposable
{
    IInstituicaoRepository Instituicoes { get; }
    ISalaRepository Salas {  get; }
    IReservaSalaRepository ReservasSalas { get; }
    IReservaMaterialRepository ReservasMateriais { get; }
    IAdministradorRepository Administradores { get; }
    IMaterialRepository Materiais { get; }
    IProfessorRepository Professores { get; }
    IMateriaRepository Materias { get; }
    Task Complete();
    

}
