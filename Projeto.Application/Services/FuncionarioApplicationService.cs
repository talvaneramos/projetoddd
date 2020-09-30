using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class FuncionarioApplicationService : IFuncionarioApplicationService
    {
        //atributo
        private readonly IFuncionarioDomainService funcionarioDomainService;

        //construtor com entrada de argumentos
        public FuncionarioApplicationService(IFuncionarioDomainService funcionarioDomainService)
        {
            this.funcionarioDomainService = funcionarioDomainService;
        }

        public void Insert(FuncionarioCadastroModel model)
        {
            var funcionario = new Funcionario();

            funcionario.Nome = model.Nome;
            funcionario.Cpf = model.Cpf;
            funcionario.Salario = decimal.Parse(model.Salario);
            funcionario.DataAdmissao = DateTime.Parse(model.DataAdmissao);

            funcionarioDomainService.Insert(funcionario);
        }

        public void Update(FuncionarioEdicaoModel model)
        {
            var funcionario = new Funcionario();

            funcionario.IdFuncionario = int.Parse(model.IdFuncionario);
            funcionario.Nome = model.Nome;
            funcionario.Cpf = model.Cpf;
            funcionario.Salario = decimal.Parse(model.Salario);
            funcionario.DataAdmissao = DateTime.Parse(model.DataAdmissao);

            funcionarioDomainService.Update(funcionario);
        }

        public void Delete(int id)
        {
            //buscar o funcionario pelo id
            var funcionario = funcionarioDomainService.GetById(id);

            //verificar se o funcionario foi encontrado
            if(funcionario != null)
            {
                //excluindo o funcionario
                funcionarioDomainService.Delete(funcionario);
            }
            else
            {
                //lançar uma exceção
                throw new Exception("Erro! Funcionário não encontrado.");
            }
        }

        public List<FuncionarioConsultaModel> GetAll()
        {
            var lista = new List<FuncionarioConsultaModel>();

            foreach (var item in funcionarioDomainService.GetAll())
            {
                var model = new FuncionarioConsultaModel();

                model.IdFuncionario = item.IdFuncionario.ToString();
                model.Nome = item.Nome;
                model.Cpf = item.Cpf;
                model.Salario = item.Salario.ToString();
                model.DataAdmissao = item.DataAdmissao.ToString("dd/MM/yyyy");

                model.Dependentes = new List<DependenteConsultaModel>();

                foreach (var dependente in item.Dependentes)
                {
                    var modelDependente = new DependenteConsultaModel();

                    modelDependente.IdDependente = dependente.IdDependente.ToString();
                    modelDependente.Nome = dependente.Nome;
                    modelDependente.DataNascimento = dependente.DataNascimento.ToString("dd/MM/yyyy");
                    modelDependente.IdFuncionario = dependente.IdFuncionario.ToString();

                    model.Dependentes.Add(modelDependente);
                }

                lista.Add(model);
            }

            return lista;
        }

        public FuncionarioConsultaModel GetById(int id)
        {
            var funcionario = funcionarioDomainService.GetById(id);

            if(funcionario != null)
            {
                var model = new FuncionarioConsultaModel();

                model.IdFuncionario = funcionario.IdFuncionario.ToString();
                model.Nome = funcionario.Nome;
                model.Cpf = funcionario.Cpf;
                model.Salario = funcionario.Salario.ToString();
                model.DataAdmissao = funcionario.DataAdmissao.ToString("dd/MM/yyyy");

                model.Dependentes = new List<DependenteConsultaModel>();

                foreach (var dependente in funcionario.Dependentes)
                {
                    var modelDependente = new DependenteConsultaModel();

                    modelDependente.IdDependente = dependente.IdDependente.ToString();
                    modelDependente.Nome = dependente.Nome;
                    modelDependente.DataNascimento = dependente.DataNascimento.ToString("dd/MM/yyyy");
                    modelDependente.IdFuncionario = dependente.IdFuncionario.ToString();

                    model.Dependentes.Add(modelDependente);
                }

                return model;
            }
            else
            {
                throw new Exception("Erro! Funcionário não encontrado.");
            }
        }
    }
}
