using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class DependenteMap : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            //nome da tabela
            builder.ToTable("Dependente");

            //chave primária
            builder.HasKey(d => d.IdDependente);

            //campos
            builder.Property(d => d.IdDependente)
                .HasColumnName("IdDependente");

            builder.Property(d => d.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(d => d.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(d => d.IdFuncionario)
                .HasColumnName("IdFuncionario")
                .IsRequired();

            //Relacionamento 1 para MUITOS
            builder.HasOne(d => d.Funcionario) //Dependente TEM 1 Funcionario
                .WithMany(f => f.Dependentes) //Funcionario TEM MUITOS Dependentes
                .HasForeignKey(d => d.IdFuncionario); //Chave estrangeira
        }
    }
}
