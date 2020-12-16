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
    [Authorize(Roles = "1")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController] 
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuario _tipousuarioRepository;
        public TipoUsuarioController(ITipoUsuario tipoUsuario)
        {
            _tipousuarioRepository = tipoUsuario;
        }

        /// <summary>
        /// Controller responsavél por cadastrar um novo tipo de usuário.
        /// </summary>
        /// <response code="201">Retorna status code 200, listar todos tipo de usuários do sistema.</response>
        /// <response code="403">Retorna status code 404 um não encontrado, não tiver nenhum tipo de usuário.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)] //Retorna um Ok caso o tipo usuário seja cadastrado 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] //Retorna um bad request caso dê algum problema ao cadastrar um tipo usuário
        public IActionResult Post(DbTipoUsuario tipousuario)
        {
            try
            {
                if (tipousuario != null)
                {
                    _tipousuarioRepository.Cadastrar(tipousuario);
                    return Created("cadastrado", tipousuario);
                }
                else
                {
                    return Unauthorized();
                }

            }
            catch
            {
                return BadRequest("Verifique as informações, todas precisam ser válidas!");
            }
        }


        /// <summary>
        /// Controller responsavél por deletar um tipo de usuário.
        /// </summary>
        /// <response code="200">Retorna status code 200, deletar um tipo de usuário.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso não existir o ID.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                var tipo = _tipousuarioRepository.BuscarId(id);
                if (tipo != null)
                {
                    _tipousuarioRepository.Deletar(id);
                    return Ok("Tipo Usuario removido");
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest(400);
            }
        }


        /// <summary>
        /// Controller responsavél por listar todos tipo de usuários.
        /// </summary>
        /// <response code="200">Retorna status code 200, listar todos tipo de usuários do sistema.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, se não encontrar nenhum tipo de usuário.</response>   
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var buscar = _tipousuarioRepository.Listar();
            if (buscar.Count != 0)
            {
                return StatusCode(200, buscar);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Controller responsavél por buscar um tipo de usuário pelo seu ID.
        /// </summary>
        /// <response code="200">Retorna status code 200, buscar o tipo de usuário pelo seu ID.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, se não existir o ID.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public IActionResult GetId(int id)
        {
            try
            {
                DbTipoUsuario tipousuario = _tipousuarioRepository.BuscarId(id);
                if (tipousuario != null)
                    return Ok(tipousuario);
                else
                    return NotFound();
            }
            catch
            {
                return NotFound(404);
            }
        }

        /// <summary>
        /// Controller responsavél por atualizar um tipo de usuário pelo ID e body.
        /// </summary>
        /// <response code="200">Retorna status code 200, atualizar um tipo de usuário.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso o ID do tipo de usuário não exista.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public IActionResult PulIdUrl(int id, DbTipoUsuario tipousuarioAtualizado)
        {
            try
            {
                var buscar = _tipousuarioRepository.BuscarId(id);
                if (buscar != null)
                {
                    _tipousuarioRepository.AtualizarTipoUsuarioId(id, tipousuarioAtualizado);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest("Não foi possivel atualizar a informação");
            }
        }
    }
}
