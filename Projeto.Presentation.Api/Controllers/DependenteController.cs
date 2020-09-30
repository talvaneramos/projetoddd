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
    public class DependenteController : ControllerBase
    {
        //atributo
        private readonly IDependenteApplicationService dependenteApplicationService;

        //construtor para inicialização do atributo
        public DependenteController(IDependenteApplicationService dependenteApplicationService)
        {
            this.dependenteApplicationService = dependenteApplicationService;
        }

        [HttpPost]
        public IActionResult Post(DependenteCadastroModel model)
        {
            try
            {
                dependenteApplicationService.Insert(model);
                return Ok("Dependente cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(DependenteEdicaoModel model)
        {
            try
            {
                dependenteApplicationService.Update(model);
                return Ok("Dependente atualizado com sucesso.");
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
                dependenteApplicationService.Delete(id);
                return Ok("Dependente excluído com sucesso.");
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
                return Ok(dependenteApplicationService.GetAll());
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
                return Ok(dependenteApplicationService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
