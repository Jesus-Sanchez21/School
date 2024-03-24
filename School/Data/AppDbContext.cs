using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno { Id = 1, Nome = "João Miguel Antunes", Idade = 16, Numero = 1 },
                new Aluno { Id = 2, Nome = "Maria Joana Antão", Idade = 12, Numero = 2 },
                new Aluno { Id = 3, Nome = "André Santos Sousa", Idade = 16, Numero = 3 }
                );
            
            modelBuilder.Entity<Professor>().HasData(
                new Professor { Id = 1, Nome = "Gonçalo Manuel guerreiro"},
                new Professor { Id = 2, Nome = "Maria Ana Joana" }
                );
        }

    }
}
