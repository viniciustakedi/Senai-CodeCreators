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
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private readonly IUsuarios _usuario;
        private readonly IEmpresas _empresa;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuariosController(IUsuarios usuario, IEmpresas empresa)
        {
            _usuario = usuario;
            _empresa = empresa;
        }

        /// <summary>
        /// Lista todos os usuários do sistema
        /// </summary>
        /// <returns>Lista de usuário</returns>
        [HttpGet]
        //[Authorize(Roles = "1")]
        public IActionResult Get()
        {
            var buscar = _usuario.Listar();
            if (buscar.Count != 0)
            {
                return Ok(buscar);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Lista um usuário por id especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O usuário buscado</returns>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var buscar = _usuario.BuscarPorId(id);
            if (buscar != null)
            {
                return Ok(buscar);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Cadastra um novo usuário no sistema
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns>O usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Post(DbUsuarios novoUsuario)
        {
            if (novoUsuario.IdTipoUsuario == 3 || novoUsuario.IdTipoUsuario == 4)
            {
                var buscarUsuario = _usuario.BuscarPorEmail(novoUsuario.Email);
                var buscarEmpresa = _empresa.SearchByEmpresa(novoUsuario.Email, "");

                if (buscarUsuario == null && buscarEmpresa == null)
                {

                    // Faz a chamada para o método
                    _usuario.Cadastrar(novoUsuario);

                    // Retorna um status code
                    return StatusCode(201);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return StatusCode(403);
            }
        }

        /// <summary>
        /// Atualiza as informações do usuário selecionado pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioAtualizado"></param>
        /// <returns>Usuario atualizado</returns>
        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Put(int id, DbUsuarios usuarioAtualizado)
        {
            var busca = _usuario.BuscarPorId(id);
            if (busca != null)
            {
                // Faz a chamada para o método
                _usuario.Atualizar(id, usuarioAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Deleta um usuário pelo id do sistema
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario deletado</returns>
        [HttpDelete("{id}")]
        //[Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            var buscar = _usuario.BuscarPorId(id);
            if (buscar != null)
            {
                // Faz a chamada para o método
                _usuario.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            else
            {
                return NotFound();
            }
        }
    }
}