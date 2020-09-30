using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //nome da tabela
            builder.ToTable("Funcionario");

            //chave primária
            builder.HasKey(f => f.IdFuncionario);

            //campos da tabela
            builder.Property(f => f.IdFuncionario)
                .HasColumnName("IdFuncionario");

            builder.Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DataAdmissao")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(f => f.Salario)
               .HasColumnName("Salario")
               .HasColumnType("decimal(18,2)")
               .IsRequired();
        }
    }
}
