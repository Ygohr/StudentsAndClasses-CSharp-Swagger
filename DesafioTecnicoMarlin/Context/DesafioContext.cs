using DesafioTecnicoMarlin.Model;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoMarlin.Context
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TurmaAluno>()
                .HasKey(ta => new { ta.idTurma, ta.idAluno });

            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.id);

            modelBuilder.Entity<Aluno>()
                .HasIndex(a => a.matricula)
                .IsUnique();            
        }

        public DbSet<Login> t_Login { get; set; }
        public DbSet<Aluno> t_Aluno { get; set; }
        public DbSet<Turma> t_Turma { get; set; }
        public DbSet<TurmaAluno> t_Turma_Aluno { get; set; }
    }
}
