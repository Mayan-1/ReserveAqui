using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReserveAqui.Infra.Config.Data;
using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Infra.Config;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Infra.Config.Repositories.ProfessorRepository;
using ReserveAqui.Core.Interfaces.Repositories.AdministradorRepository;
using ReserveAqui.Infra.Config.Repositories.AdministradorRepository;
using ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;
using ReserveAqui.Infra.Config.Repositories.InstituicaoRepository;
using ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;
using ReserveAqui.Infra.Config.Repositories.ReservaMaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;
using ReserveAqui.Infra.Config.Repositories.ReservaSalaRepository;
using ReserveAqui.Core.Interfaces.Repositories.SalaRepository;
using ReserveAqui.Infra.Config.Repositories.SalaRepository;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;
using ReserveAqui.Infra.Config.Repositories.MateriaRepository;
using ReserveAqui.Infra.Config.Repositories.MaterialRepository;
using ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;
using ReserveAqui.Core.Interfaces.Repositories.TurmaRepository;
using ReserveAqui.Infra.Config.Repositories.TurmaRepository;
using ReserveAqui.Core.Interfaces.Repositories.TurnoRepository;
using ReserveAqui.Infra.Config.Repositories.TurnoRepository;

namespace ReserveAqui.Infra
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services,
       IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IAdministradorRepository, AdministradorRepository>();
            services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
            services.AddScoped<IReservaMaterialRepository, ReservaMaterialRepository>();
            services.AddScoped<IReservaSalaRepository, ReservaSalaRepository>();
            services.AddScoped<ISalaRepository, SalaRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<ITurnoRepository, TurnoRepository>();
        }
    }
}
