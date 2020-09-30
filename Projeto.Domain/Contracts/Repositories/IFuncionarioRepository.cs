using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IFuncionarioRepository
        : IBaseRepository<Funcionario>
    {
        /*
         * Método para retornar 1 Funcionário atraves do CPF
         */ 
        Funcionario GetByCpf(string cpf);

        /*
         * Método para retornar a quantidade de dependentes
         * de um determinado funcionário
         */ 
        int CountDependentes(int idFuncionario);
    }
}
