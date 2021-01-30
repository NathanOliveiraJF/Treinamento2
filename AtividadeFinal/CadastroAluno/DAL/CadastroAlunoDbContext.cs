using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAluno.DAL
{
    class CadastroAlunoDbContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Trusted_Connection=true;Persist Security Info=False;Initial Catalog=CadastroAluno;Data Source=DESKTOP-15GH744\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Enderecos)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            //Para não repetir a matrícula.
            modelBuilder.Entity<Aluno>()
                .HasIndex(e => e.Matricula).IsUnique();
        }
    }
}
