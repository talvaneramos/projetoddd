using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.Models
{
    public class FuncionarioCadastroModel
    {
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
