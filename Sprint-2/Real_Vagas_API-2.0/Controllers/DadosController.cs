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
    public class DadosController : ControllerBase
    {
        private readonly IDados _dado;

        public DadosController(IDados dados)
        {
            _dado = dados;
        }

        /// <summary>
        /// Controller responsavél por listar todos dados do sistema.
        /// </summary>
        /// <response code="200">Retorna status code 200, listar todos dados do sistema.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, não tiver nenhum dado.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpGet]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var dados = _dado.Listar();
                if (dados.Count != 0)
                {
                    return Ok(dados);
                }
                else
                {
                    return NotFound("Nenhum dado encontrado!!!");
                }
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Controller responsavél por buscar um dado pelo ID.
        /// </summary>
        /// <response code="200">Retorna status code 200, listar o dado buscado pelo ID.</response>   
        /// <response code="404">Retorna status 404 um não encontrado, caso nenhum dado for encontrado com aquele ID.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByid(int id)
        {
            try
            {
                DbDados dadoBuscado = _dado.BuscarPorId(id);

                if (dadoBuscado != null)
                {
                    return Ok(dadoBuscado);
                }

                return NotFound("Nenhum dado encontrado pelo ID informado!!!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Controller responsavél por cadastrar um novo dado.
        /// </summary>
        /// <response code="201">Retorna status code 201 criado, e o dado será cadastrado.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpPost]
        //[Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(DbDados dados)
        {
            try
            {
                // Faz a chamada para o método
                int respost = _dado.Cadastrar(dados);

                // Retorna um status code
                return StatusCode(201, respost);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }


        /// <summary>
        /// Controller responsavél por atualizar um dado.
        /// </summary>
        /// <response code="204">Retorna status 404 um não encontrado caso o email já estiver cadastrado no sistema.</response>   
        /// <response code="404">Retorna status 404 um não encontrado caso o email já estiver cadastrado no sistema.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpPut("{id}")]
        [Authorize(Roles = "3,4")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, DbDados dadoAtualizado)
        {
            try
            {
                DbDados dadoBuscado = _dado.BuscarPorId(id);

                if (dadoBuscado != null)
                {

                    _dado.Atualizar(id, dadoAtualizado);


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
        /// Controller responsavél por deletar um dado.
        /// </summary>
        /// <response code="202">Retorna status 404 um não encontrado caso o email já estiver cadastrado no sistema.</response>   
        /// <response code="404">Retorna status 404 um não encontrado caso o email já estiver cadastrado no sistema.</response>   
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            try
            {
                DbDados dadoBuscado = _dado.BuscarPorId(id);

                if (dadoBuscado != null)
                {
                    _dado.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum dado encontrado para o ID informado");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}