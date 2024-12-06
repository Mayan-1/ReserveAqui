using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Identity.User;

namespace ReserveAqui.Infra.Config.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Administrador> Administrador { get; set; }
    public DbSet<Instituicao> Instituicao { get; set; }
    public DbSet<Professor> Professor { get; set; }
    public DbSet<Sala> Sala { get; set; }
    public DbSet<Material> Material { get; set; }
    public DbSet<Materia> Materia { get; set; } 
    public DbSet<ReservaSala> ReservaSala { get; set; }
    public DbSet<ReservaMaterial> ReservaMaterial { get; set; }
    public DbSet<Turma> Turma { get; set; }
    public DbSet<Turno> Turno { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Professor>()
            .HasOne(m => m.Materia)
            .WithMany(p => p.Professores)
            .HasForeignKey(m => m.MateriaId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
