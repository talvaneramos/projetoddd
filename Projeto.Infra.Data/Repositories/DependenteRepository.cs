using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class DependenteRepository : BaseRepository<Dependente>, IDependenteRepository
    {
        //atributo
        private readonly DataContext dataContext;

        //construtor para injeção de dependência
        public DependenteRepository(DataContext dataContext)
            : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        //sobrescrever a consulta GetAll
        public override List<Dependente> GetAll()
        {
            return dataContext
                    .Dependente
                    .Include(d => d.Funcionario) //JOIN
                    .ToList();
        }

        //sobrescrever a consulta GetById
        public override Dependente GetById(int id)
        {
            return dataContext
                    .Dependente
                    .Include(d => d.Funcionario) //JOIN
                    .FirstOrDefault(d => d.IdDependente == id);
        }
    }
}
