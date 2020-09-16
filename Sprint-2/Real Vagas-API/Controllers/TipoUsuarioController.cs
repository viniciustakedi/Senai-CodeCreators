using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using Real_Vagas_API.Repositories;

namespace Real_Vagas_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuario _tipousuarioRepository { get; set; }
        public TipoUsuarioController()
        {
            _tipousuarioRepository = new TipoUsuarioRepository();
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
                _tipousuarioRepository.Cadastrar(tipousuario);

                return Created("cadastrado", tipousuario);
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
                _tipousuarioRepository.Deletar(id);
                return Ok("Tipo Usuario removido");
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
        public IEnumerable<DbTipoUsuario> Get()
        {
            return _tipousuarioRepository.Listar();
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
                return Ok(tipousuario);
            }
            catch
            {
                return NotFound(404);
            }
        }

        ///Atualizar tipo Usuario
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //Retorna um Ok caso o tipo usuário for encontrado e atualizado
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] //Retorna um não autorizado caso o usuário não tenha permissão para efetuar essa ação
        [ProducesResponseType(StatusCodes.Status404NotFound)] //Retorna um não encontrado caso o Id não for encontrado
        public IActionResult PulIdUrl(int id, DbTipoUsuario tipousuarioAtualizado)
        {
            try
            {
                _tipousuarioRepository.AtualizarTipoUsuarioId(id, tipousuarioAtualizado);
                return Ok();
            }
            catch
            {
                return BadRequest("Não foi possivel atualizar a informação");
            }
        }
    }
}
