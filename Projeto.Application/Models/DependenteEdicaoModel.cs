using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models
{
    public class DependenteEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do dependente.")]
        public string IdDependente { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do dependente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do dependente.")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id do funcionário.")]
        public string IdFuncionario { get; set; }
    }
}
