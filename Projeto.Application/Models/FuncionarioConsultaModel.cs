using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Models
{
    public class FuncionarioConsultaModel
    {
        public string IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DataAdmissao { get; set; }
        public string Salario { get; set; }

        public List<DependenteConsultaModel> Dependentes { get; set; }
    }
}
