using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class AppDataContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<IMC> IMCs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tagore.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Dados iniciais
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    AlunoId = "6d091456-5a2f-4b5a-98fc-f1a3b50a627d",
                    Nome = "João",
                    Sobrenome = "Silva",
                    Altura = 1.75,
                    Peso = 70.0,
                    CriadoEm = DateTime.Now
                },
                new Aluno
                {
                    AlunoId = "bfe4e7dc-81e4-4e47-a67b-d4fbf3e124bd",
                    Nome = "Maria",
                    Sobrenome = "Oliveira",
                    Altura = 1.65,
                    Peso = 60.0,
                    CriadoEm = DateTime.Now
                }
            );

            modelBuilder.Entity<IMC>().HasData(
                new IMC
                {
                    Id = 1,
                    AlunoId = "6d091456-5a2f-4b5a-98fc-f1a3b50a627d",
                    Peso = 70.0m,
                    Altura = 1.75m,
                    ValorIMC = 70.0m / (1.75m * 1.75m),
                    Classificacao = "Normal",
                    DataCriacao = DateTime.UtcNow
                },
                new IMC
                {
                    Id = 2,
                    AlunoId = "bfe4e7dc-81e4-4e47-a67b-d4fbf3e124bd",
                    Peso = 60.0m,
                    Altura = 1.65m,
                    ValorIMC = 60.0m / (1.65m * 1.65m),
                    Classificacao = "Normal",
                    DataCriacao = DateTime.UtcNow
                }
            );

            
            modelBuilder.Entity<IMC>()
                .HasOne(i => i.Aluno)
                .WithMany(a => a.IMCs)
                .HasForeignKey(i => i.AlunoId);
        }
    }
}
