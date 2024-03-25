using Microsoft.EntityFrameworkCore;
using School.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public DbSet<Disciplina> Disciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno { Id = 1, Nome = "João Miguel Antunes", Idade = 16, Numero = 1, TurmaId= 1 },
                new Aluno { Id = 2, Nome = "Maria Joana Antão", Idade = 12, Numero = 2, TurmaId = 1 },
                new Aluno { Id = 3, Nome = "André Santos Sousa", Idade = 16, Numero = 3, TurmaId = 2 }
                );
            
            modelBuilder.Entity<Professor>().HasData(
                new Professor { Id = 1, Nome = "Gonçalo Manuel guerreiro"},
                new Professor { Id = 2, Nome = "Maria Ana Joana" }
                );

            modelBuilder.Entity<Turma>().HasData(
                new Turma { Id = 1, Nome = "A", Ano = 7 },
                new Turma { Id = 2, Nome = "B", Ano = 4 }
                );
            modelBuilder.Entity<Disciplina>().HasData(
                new Disciplina { Id = 1, Nome = "Ciencias", Ano = 12, ProfessorId = 1 },
                new Disciplina { Id = 2, Nome = "História", Ano = 10, ProfessorId = 2 }
                );
        }

    }
}
