using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using Real_Vagas_API.Repositories;

namespace Real_Vagas_API.Controllers
{
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class DadosController : Controller
    {
        private IDados _dado;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public DadosController()
        {
            _dado = new DadosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dado.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dado.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(DbDados novoUsuario)
        {
            // Faz a chamada para o método
            _dado.Cadastrar(novoUsuario);

            // Retorna um status code
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, DbDados dadoAtualizado)
        {
            // Faz a chamada para o método
            _dado.Atualizar(id, dadoAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _dado.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }
    }
}