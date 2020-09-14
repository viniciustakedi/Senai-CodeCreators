using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Real_Vagas.API.Domains;
using Real_Vagas.API.Interfaces;
using Real_Vagas.API.Repositories;

namespace Real_Vagas.API.Controllers

{   [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private InscricaoRepository _inscricaoRepository;
        public InscricaoController()
        {
            _inscricaoRepository = new InscricaoRepository();
        }

        /// <summary>
        /// Listar Todas as incrições
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<DbInscricao> Get()
        {
            return _inscricaoRepository.Listar();
        }

        /// <summary>
        /// Buscar uma incrição pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_inscricaoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Deletar um pacote pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            //Faz a chamada para o método deletar
            _inscricaoRepository.Deletar(id);

            //Retorna um status code com uma mensagem personalizada
            return Ok($"Pacote {id} deletado");
        }


        /// <summary>
        /// Atualizar um Pacote pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="InscricaoAtulizada"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, DbInscricao InscricaoAtulizada)
        {
            _inscricaoRepository.Atualizar(id, InscricaoAtulizada);

            return StatusCode(204);
        }

      
    }
}
