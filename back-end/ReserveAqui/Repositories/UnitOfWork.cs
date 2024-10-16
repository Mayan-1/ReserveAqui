using ReserveAqui.Config;
using ReserveAqui.Repositories.AdministradoresRepository;
using ReserveAqui.Repositories.InstituicoesRepository;
using ReserveAqui.Repositories.MateriaisRepository;
using ReserveAqui.Repositories.MateriasRepository;
using ReserveAqui.Repositories.ProfessoresRepository;
using ReserveAqui.Repositories.ReservasRepository;
using ReserveAqui.Repositories.SalasRepository;

namespace ReserveAqui.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Salas = new SalaRepository(_context);
        ReservasSalas = new ReservaSalaRepository(_context);
        ReservasMateriais = new ReservaMaterialRepository(_context);
        Administradores = new AdministradorRepository(_context);
        Materiais = new MaterialRepository(_context);
        Instituicoes = new InstituicaoRepository(_context);
        Professores = new ProfessorRepository(_context);
        Materias = new MateriaRepository(_context);
    }

    public IInstituicaoRepository Instituicoes { get; private set; }
    public ISalaRepository Salas { get; private set; }
    public IReservaSalaRepository ReservasSalas { get; private set; }
    public IReservaMaterialRepository ReservasMateriais { get; private set; }
    public IAdministradorRepository Administradores { get; private set; }
    public IMaterialRepository Materiais { get; private set; }
    public IProfessorRepository Professores { get; private set; }
    public IMateriaRepository Materias { get; private set; }

    public async Task Complete()
    {
        await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }

}
