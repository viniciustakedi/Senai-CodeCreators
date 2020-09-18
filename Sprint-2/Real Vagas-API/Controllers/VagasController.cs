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
    public class VagasController : ControllerBase
    {
        private IVagas _vagas;

        public VagasController()
        {
            _vagas = new VagasRepository();
        }

        /// <summary>
        /// Método Get para listar todas as vagas
        /// </summary>        
        /// <returns>Todas as Vagas </returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_vagas.ListaVagas());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Método Post para cadastrar uma vaga
        /// </summary>
        /// <param name="VagaNova"></param>
        /// <returns>Vaga Cadastrada</returns>
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
        /// Método Get para listar uma vaga por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Vaga buscada</returns>
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
        /// Método Get para listar uma vaga pelo local
        /// </summary>
        /// <param name="LocalVaga"></param>
        /// <returns>Vagas Encontradas</returns>
        [HttpGet("Vagas/{LocalVaga}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByLocal(string LocalVaga)
        {
            try
            {
                DbVagas vagaBuscada = _vagas.BuscarPorLocal(LocalVaga);
                if (vagaBuscada != null)
                {

                    return Ok(vagaBuscada);
                }
                return NotFound("Nenhuma vaga encontrada para o Local informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Método Get para listar uma vaga pelo cargo
        /// </summary>
        /// <param name="Cargo"></param>
        /// <returns>Vagas Encontradas</returns>
        [HttpGet("VagasPorCargo/{Cargo}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByCargo(string Cargo)
        {
            try
            {
                DbVagas vagaBuscada = _vagas.BuscarPorCargo(Cargo);
                if (vagaBuscada != null)
                {
                    return Ok(vagaBuscada);
                }
                return NotFound("Nenhuma vaga encontrada para o cargo informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Método Get para listar uma vaga pela data de publicação
        /// </summary>
        /// <param name="DataPublicacao"></param>
        /// <returns>Vagas Encontradas</returns>
        [HttpGet("VagasPorData/{DataPublicacao}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByData(DateTime DataPublicacao)
        {
            try
            {
                DbVagas vagaBuscada = _vagas.BuscarPorData(DataPublicacao);
                if (vagaBuscada != null)
                {

                    return Ok(vagaBuscada);
                }
                return NotFound("Nenhuma vaga encontrada para a data informada");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        /// <summary>
        /// Método Get para listar uma vaga pelo nome da empresa
        /// </summary>
        /// <param name="EmpresaNome"></param>
        /// <returns>Vagas Encontradas</returns>
        [HttpGet("VagasPorEmpresa/{EmpresaNome}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByEmpresa(string EmpresaNome)
        {
            try
            {
                DbVagas vagaBuscada = _vagas.BuscarPorNomeEmpresa(EmpresaNome);

                if (vagaBuscada != null)
                {
                    return Ok(vagaBuscada);
                }

                return NotFound("Nenhuma vaga encontrada para a empresa informada");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

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
        /// Método Delete para deletar uma vaga
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Vaga Deletada</returns>
        [HttpDelete("{Id}")]
        [Authorize(Roles = "1,2")]
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