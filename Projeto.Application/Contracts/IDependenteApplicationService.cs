using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IDependenteApplicationService
    {
        void Insert(DependenteCadastroModel model);
        void Update(DependenteEdicaoModel model);
        void Delete(int id);

        List<DependenteConsultaModel> GetAll();
        DependenteConsultaModel GetById(int id);
    }
}
