using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        //atributo
        private readonly IFuncionarioApplicationService funcionarioApplicationService;

        //construtor para inicialização da application
        public FuncionarioController(IFuncionarioApplicationService funcionarioApplicationService)
        {
            this.funcionarioApplicationService = funcionarioApplicationService;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioCadastroModel model)
        {
            try
            {
                funcionarioApplicationService.Insert(model);
                return Ok("Funcionário cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionarioEdicaoModel model)
        {
            try
            {
                funcionarioApplicationService.Update(model);
                return Ok("Funcionário atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                funcionarioApplicationService.Delete(id);
                return Ok("Funcionário excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(funcionarioApplicationService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(funcionarioApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
