using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models
{
    public class FuncionarioEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do funcionário.")]
        public string IdFuncionario { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do funcionário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cpf do funcionário.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de admissão do funcionário.")]
        public string DataAdmissao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o salário do funcionário.")]
        public string Salario { get; set; }
    }
}
