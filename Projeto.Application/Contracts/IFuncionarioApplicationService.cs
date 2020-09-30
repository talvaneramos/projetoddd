using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IFuncionarioApplicationService
    {
        void Insert(FuncionarioCadastroModel model);
        void Update(FuncionarioEdicaoModel model);
        void Delete(int id);

        List<FuncionarioConsultaModel> GetAll();
        FuncionarioConsultaModel GetById(int id);
    }
}
