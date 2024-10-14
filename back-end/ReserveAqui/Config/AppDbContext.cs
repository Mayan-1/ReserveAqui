using Microsoft.EntityFrameworkCore;
using ReserveAqui.Models;

namespace ReserveAqui.Config;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Administrador> Administrador { get; set; }
    public DbSet<Instituicao> Instituicao { get; set; }
    public DbSet<Professor> Professor { get; set; }
    public DbSet<Sala> Sala { get; set; }
    public DbSet<Material> Material { get; set; }
    public DbSet<Materia> Materia { get; set; }
    public DbSet<ReservaSala> ReservaSala { get; set; }
    public DbSet<ReservaMaterial> ReservaMaterial { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Professor>()
            .HasMany(e => e.Materias)
            .WithMany(e => e.Professores)
            .UsingEntity<ProfessorMateria>();
    }

}
