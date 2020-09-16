using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Real_Vagas_API.Domains;
using Real_Vagas_API.Repositories;

namespace Real_Vagas_API.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class InscricaoController : Controller
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
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição 200- Ok
                return Ok(_inscricaoRepository.Listar());
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400
                return BadRequest(error);
            }
        }




        /// <summary>
        /// Buscar uma incrição pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                DbInscricao inscricaoBuscada = _inscricaoRepository.BuscarPorId(id);

                // Verifica se a incrição foi encontrada
                if (inscricaoBuscada != null)
                {
                    // Retorna a resposta da requisição 200 - Ok
                    return Ok(inscricaoBuscada);

                }

                // Retorna a resposta de requisição 404
                return NotFound("Nenhuma incrição encontrada");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400
                return BadRequest(error);
            }
        }








        /// <summary>
        /// Deletar um inscrição pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                DbInscricao inscriçãoBuscado = _inscricaoRepository.BuscarPorId(id);

                if (inscriçãoBuscado != null)
                {
                    // Faz a chamada para o método
                    _inscricaoRepository.Deletar(id);

                    // Retora a resposta da requisição 202 
                    return StatusCode(202);
                }
                // Retorna a resposta da requisição 404 - Not Found
                return NotFound("Nenhuma inscrição encontrada");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400
                return BadRequest(error);
            }

            //Faz a chamada para o método deletar


            //Retorna um status code com uma mensagem personalizada
        }


        /// <summary>
        /// Atualizar um inscrição pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="InscricaoAtulizada"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, DbInscricao InscricaoAtulizada)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto eventoBuscado
                DbInscricao inscricaoBuscada = _inscricaoRepository.BuscarPorId(id);

                // Verifica se o evento foi encontrado
                if (inscricaoBuscada != null)
                {
                    // Faz a chamada para o método
                    _inscricaoRepository.Atualizar(id, InscricaoAtulizada);

                    // Retora a resposta da requisição 204
                    return StatusCode(204);
                }

                // Retorna a resposta da requisição 404
                return NotFound("Nenhuma inscrição encontrada");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400
                return BadRequest(error);
            }
        }

    }
}
