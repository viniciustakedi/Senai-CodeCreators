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

        [HttpGet]
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

        [HttpPost]
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

        [HttpGet("{Id}")]
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

        [HttpGet("Vagas/{LocalVaga}")]
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

        [HttpGet("VagasPorCargo/{Cargo}")]
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

            [HttpGet("VagasPorData/{DataPublicacao}")]
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

        [HttpGet("VagasPorEmpresa/{EmpresaNome}")]
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

        [HttpDelete("{Id}")]
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