using CepAPI.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// Nome: Paula Almeida 
namespace CepAPI.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class EnderecoAPIController : ControllerBase
    {
        private readonly ILogger<EnderecoAPIController> _logger;
        private GerenciadorCepApi gerenciador;

        public EnderecoAPIController(ILogger<EnderecoAPIController> logger)
        {
            _logger = logger;
            this.gerenciador = new GerenciadorCepApi();
        }

        [HttpGet]
        [Route("ListarEnderecos")]
        public ActionResult<List<CEP>> ListarEnderecos()
        {
            return gerenciador.Listar();
        }

        [HttpGet]
        [Route("ListarEndereco")]
        public ActionResult<CEP> ListarEndereco(string cep)
        {
            return gerenciador.Listar(cep);
        }

        [HttpPost]
        [Route("CadastrarEndereco")]
        public ActionResult<CEP> CadastrarEndereco(CEP cep)
        {
            return gerenciador.Cadastrar(cep);
        }

        [HttpPut]
        [Route("AlterarEndereco")]
        public ActionResult<CEP> AlterarEndereco(CEP cep)
        {
            return gerenciador.Alterar(cep);
        }

        [HttpDelete]
        [Route("DeletarEndereco")]
        public IActionResult DeletarEndereco(int id)
        {
            gerenciador.Deletar(id);

            return Ok();
        }
    }
}
