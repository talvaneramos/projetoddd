using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Funcionario
    {
        //propriedades -> get/set
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }

        //relacionamentos
        //Funcionario TEM MUITOS Dependentes
        public List<Dependente> Dependentes { get; set; }
    }
}
