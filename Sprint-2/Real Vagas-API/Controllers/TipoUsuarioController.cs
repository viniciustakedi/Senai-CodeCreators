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
    [Route("api/[controller]")]

    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuario _tipousuarioRepository { get; set; }
        public TipoUsuarioController()
        {
            _tipousuarioRepository = new TipoUsuarioRepository();
        }

        //Para cadatrar tipo usuario
        [HttpPost]
        public IActionResult Post(DbTipoUsuarioDomain tipousuario)
        {
            _tipousuarioRepository.Cadastrar(tipousuario);

            return Created("cadastrado", tipousuario);
        }


        /// Deleta um Tipo de Usuario
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipousuarioRepository.Deletar(id);
            return Ok("Tipo Usuario removido");
        }


        /// Listar Tipo Usuario
        [HttpGet]
        public IEnumerable<DbTipoUsuarioDomain> Get()
        {
            return _tipousuarioRepository.Listar();
        }

        /// Buscar por Id
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            DbTipoUsuarioDomain tipousuario = _tipousuarioRepository.BuscarId(id);
            return Ok(tipousuario);
        }

        ///Atualizar tipo Usuario
        [HttpPut("{id}")]
        public IActionResult PulIdUrl(int id, DbTipoUsuarioDomain tipousuarioAtualizado)
        {
            _tipousuarioRepository.AtualizarTipoUsuarioId(id, tipousuarioAtualizado);
            return Ok();
        }


    }
}
