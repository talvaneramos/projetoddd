using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        //atributo
        private readonly DataContext dataContext;

        //construtor com entrada de argumentos
        public FuncionarioRepository(DataContext dataContext)
            : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        //sobrescrita do método GetAll
        public override List<Funcionario> GetAll()
        {
            return dataContext
                    .Funcionario
                    .Include(f => f.Dependentes) //JOIN
                    .ToList();
        }

        public override Funcionario GetById(int id)
        {
            return dataContext
                    .Funcionario
                    .Include(f => f.Dependentes) //JOIN
                    .FirstOrDefault(f => f.IdFuncionario == id);
        }

        public Funcionario GetByCpf(string cpf)
        {
            return dataContext.Funcionario
                .FirstOrDefault(f => f.Cpf.Equals(cpf));
        }

        public int CountDependentes(int idFuncionario)
        {
            return dataContext.Dependente
                .Count(d => d.IdFuncionario == idFuncionario);
        }
    }
}
