using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        /// <summary>
        /// metodo get para listar usuarios
        /// </summary>
        /// <returns>todos os usuarios</returns>
        [HttpGet]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuario.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Metodo Get para buscar um usuario pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>usuarioBuscado</returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {

                DbUsuarios usuarioBuscado = _usuario.BuscarPorId(id);


                if (usuarioBuscado != null)
                {

                    return Ok(usuarioBuscado);
                }


                return NotFound("Nenhum usuario encontrado para o id informado");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        /// <summary>
        /// Metodo post para cadastrar um usuario
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns>usuarioCadastrado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Metodo put para atualizar um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioAtualizado"></param>
        /// <returns>usuarioAtualizado</returns>
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, DbUsuarios usuarioAtualizado)
        {
            try
            {

                DbUsuarios usuarioBuscado = _usuario.BuscarPorId(id);


                if (usuarioBuscado != null)
                {

                    _usuario.Atualizar(id, usuarioAtualizado);


                    return StatusCode(204);
                }


                return NotFound("Nenhum usuário encontrado para o id informado");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        /// <summary>
        /// Metodo Delete para deletar um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario Deletado</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {

                DbUsuarios usuarioBuscado = _usuario.BuscarPorId(id);


                if (usuarioBuscado != null)
                {

                    _usuario.Deletar(id);


                    return StatusCode(202);
                }


                return NotFound("Nenhuma vaga encontrado para o ID informado");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}