using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Application.Services
{
    public class DependenteApplicationService : IDependenteApplicationService
    {
        //atributo
        private readonly IDependenteDomainService dependenteDomainService;

        //construtor com entrada de argumentos
        public DependenteApplicationService(IDependenteDomainService dependenteDomainService)
        {
            this.dependenteDomainService = dependenteDomainService;
        }

        public void Insert(DependenteCadastroModel model)
        {
            var dependente = new Dependente();

            dependente.Nome = model.Nome;
            dependente.DataNascimento = DateTime.Parse(model.DataNascimento);
            dependente.IdFuncionario = int.Parse(model.IdFuncionario);

            dependenteDomainService.Insert(dependente);
        }

        public void Update(DependenteEdicaoModel model)
        {
            var dependente = new Dependente();

            dependente.IdDependente = int.Parse(model.IdDependente);
            dependente.Nome = model.Nome;
            dependente.DataNascimento = DateTime.Parse(model.DataNascimento);
            dependente.IdFuncionario = int.Parse(model.IdFuncionario);

            dependenteDomainService.Update(dependente);
        }

        public void Delete(int id)
        {
            //buscando o dependente pelo id
            var dependente = dependenteDomainService.GetById(id);
            
            //verificando se foi encontrado
            if(dependente != null)
            {
                //excluindo o dependente
                dependenteDomainService.Delete(dependente);
            }
            else
            {
                //lançar uma exceção
                throw new Exception("Dependente não encontrado.");
            }
        }

        public List<DependenteConsultaModel> GetAll()
        {
            var lista = new List<DependenteConsultaModel>();
            
            //percorrer todos os dependentes obtidos no banco de dados
            foreach (var item in dependenteDomainService.GetAll())
            {
                var model = new DependenteConsultaModel();

                model.IdDependente = item.IdDependente.ToString();
                model.Nome = item.Nome;
                model.DataNascimento = item.DataNascimento.ToString("dd/MM/yyyy");
                model.IdFuncionario = item.IdFuncionario.ToString();

                model.Funcionario = new FuncionarioConsultaModel();
                model.Funcionario.IdFuncionario = item.Funcionario.IdFuncionario.ToString();
                model.Funcionario.Nome = item.Funcionario.Nome;
                model.Funcionario.Salario = item.Funcionario.Salario.ToString();
                model.Funcionario.DataAdmissao = item.Funcionario.DataAdmissao.ToString("dd/MM/yyyy");

                lista.Add(model); //adicionar na lista..
            }

            return lista;
        }

        public DependenteConsultaModel GetById(int id)
        {
            //buscando um dependente baseado no id
            var dependente = dependenteDomainService.GetById(id);

            //verificando se o dependente foi encontrado
            if(dependente != null)
            {
                var model = new DependenteConsultaModel();

                model.IdDependente = dependente.IdDependente.ToString();
                model.Nome = dependente.Nome;
                model.DataNascimento = dependente.DataNascimento.ToString("dd/MM/yyyy");
                model.IdFuncionario = dependente.IdFuncionario.ToString();

                model.Funcionario = new FuncionarioConsultaModel();
                model.Funcionario.IdFuncionario = dependente.Funcionario.IdFuncionario.ToString();
                model.Funcionario.Nome = dependente.Funcionario.Nome;
                model.Funcionario.Salario = dependente.Funcionario.Salario.ToString();
                model.Funcionario.DataAdmissao = dependente.Funcionario.DataAdmissao.ToString("dd/MM/yyyy");

                return model;
            }
            else
            {
                throw new Exception("Erro! Dependente não foi encontrado.");
            }
        }
    }
}
