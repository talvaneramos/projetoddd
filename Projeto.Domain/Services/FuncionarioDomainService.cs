using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class FuncionarioDomainService : BaseDomainService<Funcionario>, IFuncionarioDomainService
    {
        //atributo
        private readonly IFuncionarioRepository funcionarioRepository;

        //construtor com passagem de parametros / argumentos
        public FuncionarioDomainService(IFuncionarioRepository funcionarioRepository)
            : base(funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        public override void Insert(Funcionario obj)
        {
            //buscar o funcionário no banco de dados através do CPF
            var registro = funcionarioRepository.GetByCpf(obj.Cpf);

            //verificando se o funcionário foi encontrado
            if(registro != null)
            {
                //lançar uma exceção..
                throw new Exception("Erro. O CPF informado já encontra-se cadastrado.");
            }
            else
            {
                //cadastrar o funcionario
                funcionarioRepository.Insert(obj);
            }
        }

        public override void Update(Funcionario obj)
        {
            //buscar o funcionário no banco de dados através do CPF
            var registro = funcionarioRepository.GetByCpf(obj.Cpf);

            //verificando se o funcionário foi encontrado
            if (registro != null && registro.IdFuncionario != obj.IdFuncionario)
            {
                //lançar uma exceção..
                throw new Exception("Erro. O CPF informado já encontra-se cadastrado.");
            }
            else
            {
                //atualizar o funcionario
                funcionarioRepository.Update(obj);
            }
        }
    }
}
