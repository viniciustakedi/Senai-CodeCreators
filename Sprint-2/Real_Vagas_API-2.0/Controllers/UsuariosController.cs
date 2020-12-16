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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios _usuario;
        private readonly IEmpresas _empresa;

        public UsuariosController(IUsuarios usuario, IEmpresas empresa)
        {
            _usuario = usuario;
            _empresa = empresa;
        }

        /// <summary>
        /// Controller responsavél por listar todos os usuários.
        /// </summary>
        /// <response code="201">Retorna status code 200, listar todos usuários.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso não tiver nenhum usuário no sistema.</response>   
        [HttpGet]
        //[Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// Controller responsavél por buscar um usuário pelo seu ID
        /// </summary>
        /// <response code="200">Retorna status code 200, listar usuário buscado pelo seu ID.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso não existir seu ID.</response>   
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// Controller responsavél por cadastrar um novo usuário.
        /// </summary>
        /// <response code="201">Retorna status code 201, cadastrar um novo usuário</response>
        /// <response code="404">Retorna status code 404 não autorizado, caso de problema com cadastro.</response>   
        /// <response code="403">Retorna stauts code 403 Forbidden, caso de problema com api.</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Post(DbUsuarios novoUsuario)
        {
            if (novoUsuario.IdTipoUsuario == 1 || novoUsuario.IdTipoUsuario == 3 || novoUsuario.IdTipoUsuario == 4)
            {
                var buscarUsuario = _usuario.BuscarPorEmail(novoUsuario.Email);
                var buscarEmpresa = _empresa.BuscarPorEmpresa(novoUsuario.Email, "");

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
        /// Controller responsavél por atualizar um usuário existente.
        /// </summary>
        /// <response code="200">Retorna status code 200, atualizar um usuário.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso não existir o ID do usuário.</response>   
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, DbUsuarios usuarioAtualizado)
        {
            var busca = _usuario.BuscarPorId(id);
            if (busca != null)
            {
                // Faz a chamada para o método
                _usuario.Atualizar(id, usuarioAtualizado);

                // Retorna um status code
                return StatusCode(200);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Controller responsavél deletar um usuário pelo ID.
        /// </summary>
        /// <response code="200">Retorna status code 200, deletar um usuário pelo seu ID.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso o ID não existir.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            var buscar = _usuario.BuscarPorId(id);
            if (buscar != null)
            {
                // Faz a chamada para o método
                _usuario.Deletar(id);

                // Retorna um status code
                return StatusCode(200);
            }
            else
            {
                return NotFound();
            }
        }
    }
}