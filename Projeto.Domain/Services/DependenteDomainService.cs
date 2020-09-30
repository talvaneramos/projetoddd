using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class DependenteDomainService : BaseDomainService<Dependente>, IDependenteDomainService
    {
        private readonly IDependenteRepository dependenteRepository;
        private readonly IFuncionarioRepository funcionarioRepository;

        public DependenteDomainService(IDependenteRepository dependenteRepository, IFuncionarioRepository funcionarioRepository)
            : base(dependenteRepository)
        {
            this.dependenteRepository = dependenteRepository;
            this.funcionarioRepository = funcionarioRepository;
        }

        public override void Insert(Dependente obj)
        {
            //verificar se o dependente é maior de idade
            if(ObterIdade(obj.DataNascimento) >= 18)
            {
                throw new Exception("Erro. O dependente deve ser menor de idade.");
            }

            //verificar a quantidade de dependentes do funcionário
            var qtd = funcionarioRepository.CountDependentes(obj.IdFuncionario);

            //verificar se a quantidade é maior ou igual a 3
            if(qtd >= 3)
            {
                throw new Exception("Erro. O funcionário já possui 3 dependentes.");
            }
            else
            {
                dependenteRepository.Insert(obj);
            }
        }

        public override void Update(Dependente obj)
        {
            //verificar se o dependente é maior de idade
            if (ObterIdade(obj.DataNascimento) >= 18)
            {
                throw new Exception("Erro. O dependente deve ser menor de idade.");
            }

            //verificar a quantidade de dependentes do funcionário
            var qtd = funcionarioRepository.CountDependentes(obj.IdFuncionario);

            //verificar se a quantidade é maior ou igual a 3
            if (qtd >= 3)
            {
                throw new Exception("Erro. O funcionário já possui 3 dependentes.");
            }
            else
            {
                dependenteRepository.Update(obj);
            }
        }

        //método para calcular a idade do dependente
        private int ObterIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;

            //se não fez aniversario..
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade--;
            }

            return idade;
        }
    }
}
