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
        /// Controller responsavél por listar todas as inscrições do sistema.
        /// </summary>
        /// <response code="200">Retorna status code 200 OK, listar todas inscrições do sistemas.</response>
        /// <response code="404">Retorna status code 404 não encontrado, não tiver nenhuma inscrição cadastrada.</response>
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpGet]
        //[Authorize(Roles = "1,2")]
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
        /// Controller responsavél por listar todas as inscrições de usuário pelo seu ID.
        /// </summary>
        /// <response code="200">Retorna status code 200 OK, listar todas inscrições do usuário solicitado.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso não existir nenhuma inscrição com aquele ID no sistema.</response>
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpGet("ListarById/id")]
        //[Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarById(int id)
        {
            try
            {
                List<DbInscricao> inscricaoBuscada = _inscricaoRepository.ListarById(id);

                // Verifica se a incrição foi encontrada
                if (inscricaoBuscada.Count != 0)
                {
                    // Retorna a resposta da requisição 200 - Ok
                    return Ok(inscricaoBuscada);
                }

                // Retorna a resposta de requisição 404
                return NotFound("Nenhuma inscrição encontrada!!!");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Controller responsavél por listar todas as inscrições de empresa pelo seu ID.
        /// </summary>
        /// <response code="200">Retorna status code 200 OK, listar todas inscrições daquela empresa.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso não existir nenhuma inscrição no sistema.</response>
        [HttpGet("ListarByIdEmpresa/id")]
       // [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarByIdEmpresa(int id)
        {
           
                List<DbInscricao> inscricaoBuscada = _inscricaoRepository.ListarByIdEmpresa(id);

                // Verifica se a incrição foi encontrada
                if (inscricaoBuscada.Count != 0)
                {
                    // Retorna a resposta da requisição 200 - Ok
                    return Ok(inscricaoBuscada);

                }
            else
            {
                // Retorna a resposta de requisição 404
                return NotFound("Nenhuma inscrição encontrada!!!");
            }
           
        }

        /// <summary>
        /// Controller responsavél por listar todas as inscrições de uma vaga pelo seu ID.
        /// </summary>
        /// <response code="200">Retorna status code 200 OK, listar todas inscrições daquela vaga.</response>
        [HttpGet("ListarByIdVaga/id")]
        //[Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarByIdVaga(int id)
        {
            List<DbInscricao> inscricaoBuscada = _inscricaoRepository.ListarByIdVaga(id);

            return Ok(inscricaoBuscada);
        }

        /// <summary>
        /// Controller responsavél por cadastrar uma inscrição.
        /// </summary>
        /// <response code="200">Retorna status code 201 criado, cadastra uma nova inscrição.</response>
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult post(DbInscricao inscricaos)
        {
            try
            {
                // Retorna a resposta da requisição 200- Ok
                _inscricaoRepository.Cadastrar(inscricaos);
                return Ok();
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Controller responsavél por buscar uma inscrição pelo seu ID.
        /// </summary>
        /// <response code="200">Retorna status code 200 OK, listar a inscrição solicitada.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso não existir nenhuma inscrição pelo o ID.</response>
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpGet("{id}")]
     //   [Authorize(Roles = "1,2")]
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
        /// Controller responsavél por deletar uma inscrição pelo seu ID.
        /// </summary>
        /// <response code="200">Retorna status code 200 OK, deletar a inscrição do sistema.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso não existir o ID.</response>
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpDelete("{id}")]
        //[Authorize(Roles = "1")]
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
        /// Controller responsavél por atualizar uma inscrição pelo seu ID e body.
        /// </summary>
        /// <response code="204">Retorna status code 204 aceito, atualizar uma inscrição.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso não existir nenhuma inscrição daquele ID.</response>
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpPut("{id}")]
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

