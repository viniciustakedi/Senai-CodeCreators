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
    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]
    // Define que é um controlador de API
    [ApiController]
    public class DadosController : ControllerBase
    {
        private readonly IDados _dado;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public DadosController(IDados dados)
        {
            _dado = dados;
        }

        /// <summary>
        /// Método listar Dados
        /// </summary>
        /// <returns>Todos os dados</returns>
        [HttpGet]
        //[Authorize(Roles = "1")]
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
                    return NotFound();
                }
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Buscar um dado por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>dadoBuscado</returns>
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

                return NotFound("Nenhum dado encontrado para o id informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo dado
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns>NovoUsuario</returns>
        [HttpPost]
        //[Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(DbDados novoUsuario)
        {
            try
            {
                // Faz a chamada para o método
                int respost = _dado.Cadastrar(novoUsuario);

                // Retorna um status code
                return StatusCode(201, respost);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }


        /// <summary>
        /// Atualiza um dado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dadoAtualizado"></param>
        /// <returns>dadoAtualizado</returns>
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
        /// Metodo para Deletar um dado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vaga Deletada</returns>
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