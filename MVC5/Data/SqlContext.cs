using Microsoft.EntityFrameworkCore;
using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC5.Data
{
    public class SqlContext : DbContext
    {
        // construtor
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        // mapear tabelas
        public DbSet<Instituicao> Instituicaos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        // 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Departamento>().ToTable("Departamento");
        }

        //pode fazer a configuração direto do dbcontext, normalmente e feito pela startup usando DI.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Modelo;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}
    }
}
