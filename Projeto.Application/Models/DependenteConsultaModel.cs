using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Models
{
    public class DependenteConsultaModel
    {
        public string IdDependente { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string IdFuncionario { get; set; }

        //Relacionamento
        public FuncionarioConsultaModel Funcionario { get; set; }
    }
}
