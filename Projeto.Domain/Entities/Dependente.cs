using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class Dependente
    {
        //propriedades -> get/set
        public int IdDependente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdFuncionario { get; set; }

        //relacionamentos
        //Dependente TEM 1 Funcionario
        public Funcionario Funcionario { get; set; }
    }
}
