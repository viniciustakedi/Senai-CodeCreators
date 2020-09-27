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
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricao _inscricaoRepository;
        public InscricaoController(IInscricao inscricao)
        {
            _inscricaoRepository = inscricao;
        }

        /// <summary>
        /// Listar Todas as incrições
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição 200- Ok
                var inscricao = _inscricaoRepository.Listar();
                if (inscricao != null)
                {
                    return Ok(inscricao);
                }
                else
                {
                    return NotFound();
                }
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
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

