
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    public class VagasController : ControllerBase
    {
        private readonly IVagas _vagas;

        public VagasController(IVagas vagas)
        {
            _vagas = vagas;
        }

        /// <summary>
        /// Controller responsavél por listar todas as vagas.
        /// </summary>
        /// <response code="200">Retorna status code 200, listar todas as vagas.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso não tiver nenhuma vaga cadastrar.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpGet]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var buscar = _vagas.ListaVagas();
                if (buscar.Count != 0)
                {
                    return Ok(buscar);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Controller responsavél por cadastrar uma nova vaga no sistema.
        /// </summary>
        /// <response code="200">Retorna status code 200, cadastrar uma nova vaga.</response>
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpPost]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(DbVagas VagaNova)
        {
            try
            {
                _vagas.Cadastrar(VagaNova);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Controller responsavél por buscar uma vaga pelo seu ID.
        /// </summary>
        /// <response code="200">Retorna status code 200, listar a vaga buscada pelo ID.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso não existir uma vaga com ID.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpGet("{Id}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(int Id)
        {
            try
            {

                DbVagas vagaBuscada = _vagas.BuscarPorId(Id);

                if (vagaBuscada != null)
                {
                    return Ok(vagaBuscada);
                }
                return NotFound("Nenhuma vaga encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }


        /// <summary>
        /// Controller responsavél por atualizar uma vaga.
        /// </summary>
        /// <response code="200">Retorna status code 200, vaga será atualizada.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso não existir o ID.</response> 
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpPut("{Id}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int Id, DbVagas VagaAtualizada)
        {
            try
            {

                DbVagas vagaBuscada = _vagas.BuscarPorId(Id);


                if (vagaBuscada != null)
                {

                    _vagas.Atualizar(Id, VagaAtualizada);


                    return StatusCode(204);
                }


                return NotFound("Nenhuma vaga encontrado para o ID informado");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }


        /// <summary>
        /// Controller responsavél por listar todas vagas de empresa pelo ID.
        /// </summary>
        /// <response code="200">Retorna status code 200, listar todas vagas daquela empresa.</response>
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpGet("VagaByIdEmpresa/id")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByEmpresa(int Id)
        {
            try
            {
                var buscar = _vagas.ListaByIdEmpresa(Id);
                return Ok(buscar);

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Controller responsavél por deletar um vaga pelo o ID.
        /// </summary>
        /// <response code="202">Retorna status code 202 accepted, deletar uma vaga pelo ID.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso não encontrar nenhuma vaga.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpDelete("{Id}")]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int Id)
        {
            try
            {
                DbVagas vagaBuscada = _vagas.BuscarPorId(Id);
                if (vagaBuscada != null)
                {

                    _vagas.Deletar(Id);


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