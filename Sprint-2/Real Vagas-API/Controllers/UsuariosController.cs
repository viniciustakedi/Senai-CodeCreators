using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class UsuariosController : Controller
    {
        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarios _usuario;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuario = new UsuariosRepository();
        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult Get()
        {
            return Ok(_usuario.Listar());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            return Ok(_usuario.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(DbUsuarios novoUsuario)
        {
            if (novoUsuario.IdTipoUsuario == 3 | novoUsuario.IdTipoUsuario == 4)
            {
                // Faz a chamada para o método
                _usuario.Cadastrar(novoUsuario);

                // Retorna um status code
                return StatusCode(201);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, DbUsuarios usuarioAtualizado)
        {
            // Faz a chamada para o método
            _usuario.Atualizar(id, usuarioAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _usuario.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }
    }
}