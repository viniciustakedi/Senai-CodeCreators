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
        /// Método Post para cadastrar um usuário
        /// </summary>
        /// <param name="tipousuario"></param>
        /// <returns>Tipo Usuário Cadastrado</returns>
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
        /// Método Delete para deletar um tipo usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TipoUsuario Deletado</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)] //Retorna um accepted caso o tipo usuário for encontrado e deletado
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Retorna um NotFound caso o tipo usuário não seja encontrado
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
        /// Método Get para listar todos os tipos de usuários
        /// </summary>
        /// <returns>Lista tipos usuários</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] //Retorna um Ok caso ele encontre todos os tipos de usuários
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] //Retorna um Unauthorized caso o usuário não tenha permissão para listar os tipos de usuários
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
        /// Busca um tipo usuário pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Busca tipo usuario pelo Id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Retorna um Ok caso o tipo usuário for encontrado
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] //Retorna um não autorizado caso o usuário não tenha permissão para ver essa informação
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Retorna um não encontrado caso o Id não for encontrado
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
        /// Atualizar um tipo usuário por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipousuarioAtualizado"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Retorna um Ok caso o tipo usuário for encontrado e atualizado
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] //Retorna um não autorizado caso o usuário não tenha permissão para efetuar essa ação
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Retorna um não encontrado caso o Id não for encontrado
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
