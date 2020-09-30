using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //validações

namespace Projeto.Application.Models
{
    public class DependenteCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do dependente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do dependente.")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do funcionário.")]
        public string IdFuncionario { get; set; }
    }
}
