using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    //REGRA 1: Herdar DbContext
    public class DataContext : DbContext
    {
        //REGRA 2: Construtor para receber como parametro as configurações
        //de ambiente do EntityFramework (string de conexão, etc)
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) //construtor da superclasse
        {

        }

        //REGRA 3: Declarar um get/set para cada entidade usando DbSet
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Dependente> Dependente { get; set; }

        //REGRA 4) Sobrescrever o método OnModelCreating
        //adicionar no método as classes de mapeamento (Map)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new DependenteMap());
        }
    }
}
