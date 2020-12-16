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
using Real_Vagas_API.ViewModels;

namespace Real_Vagas_API.Controllers
{ 
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresas _EmpresasRepository;

        public EmpresasController(IEmpresas Empresa)
        {
            _EmpresasRepository = Empresa;
        }

        /// <summary>
        /// Controller Responsavél por deletar usuário do tipo empresa.
        /// </summary>
        /// <response code="202">Retorna status code 202 aceito, caso o ID for existente, assim deletado o usuário do tipo empresa do sistema.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o ID não existe no sistema.</response>   
        [HttpDelete("{ID}")]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarEmpresa(int ID)
        {
            var delete = _EmpresasRepository.BuscarPorId(ID);
            if (delete != null)
            {
                _EmpresasRepository.Delete(ID);
                return StatusCode(202, "Empresa deletada com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Nenhuma empresa foi encontrada com ID informado!!!");
            }
        }

        /// <summary>
        /// Controller responsável por listar todos os usuários do tipo empresa do sistema.
        /// </summary>
        /// <response code="200">Retorna status code 200 OK, listar todos usuários do tipo empresa.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso não existir empresa.</response>
        [HttpGet]
        //[Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarEmpresas()
        {
            var Empresas = _EmpresasRepository.Get();
            if (Empresas.Count != 0)
            {
                return Ok(Empresas);
            }
            else
            {
                return StatusCode(404, "Nenhuma empresa encontrada no sistema!!!");
            }
        }

        /// <summary>
        /// Controller responsável por cadastrar uma empresa no sistema.
        /// </summary>
        /// <response code="201">Retorna status code 201 foi criado a empresa, cadastrado um usuário tipo empresa</response>
        /// <response code="400">Retorna status code 400 bad request, caso a empresa já estiver cadastrada.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastraEmpresa(DbEmpresas Empresa)
        {
            UsuariosRepository Usuario = new UsuariosRepository();
            var busca = _EmpresasRepository.BuscarPorEmpresa(Empresa.Email, Empresa.Cnpj);
            var buscar = Usuario.BuscarPorEmail(Empresa.Email);

            if (busca == null && buscar == null)
            {
                _EmpresasRepository.Post(Empresa);
                return StatusCode(201, "Empresa foi criada com sucesso!!!");
            }
            else
            {
                return StatusCode(400, "Essa cnpj ou email já cadstrado no sistema!!!");
            }
        }

        /// <summary>
        /// Controller responsável por atualizar os dados de uma empresa no sistema.
        /// </summary>
        /// <response code="200">Retorna status code 200 ok, os dados serão atualizados no banco de dados. </response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o ID informado não existir.</response>
        [HttpPut]
        //[Authorize(Roles = "2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizarEmpresa(DbEmpresas Empresa)
        {
            var Busca = _EmpresasRepository.BuscarPorId(Empresa.Id);

            if (Busca != null)
            {
                _EmpresasRepository.Put(Empresa);
                return StatusCode(200, "Empresa atualizada com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Empresa não encontrada, ID digitado incorreto!!!");
            }
        }

        /// <summary>
        /// Controller responsável por buscar dados do banco de dados apartir do email ou cnpj.
        /// </summary>
        /// <response code="200">Retorna status code 200 ok, listar os dados buscados. </response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o email ou cnpj informado não estiver cadastrados.</response>
        [HttpPost("BuscarPorEmpresa")]
        //[Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorEmpresa(EmpresaViewModel Empresa)
        {
            var Busca = _EmpresasRepository.BuscarPorEmpresa(Empresa.Email, Empresa.CNPJ);

            if (Busca != null)
            {
                return Ok(Busca);
            }
            else
            {
                return StatusCode(404, "Nenhuma empresa encontrada com esse email e cnpj!!!");
            }
        }

        /// <summary>
        /// Controller responsável por buscar dados de uma empresa apartir do seu ID.
        /// </summary>
        /// <response code="200">Retorna status code 200 ok, listar o dados da empresa pelo ID informado.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o ID informado não existir.</response>
        [HttpGet("BuscarPeloID/{ID}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPeloID(int ID)
        {
            var Busca = _EmpresasRepository.BuscarPorId(ID);

            if (Busca != null)
            {
                return Ok(Busca);
            }
            else
            {
                return StatusCode(404, "Nenhuma empresa encontrada com ID informado!!!");
            }
        }

        /// <summary>
        /// Controller responsável por buscar todas as vagas cadastradas nós últimos 30 dias por uma empresa, apartir do ID da empresa.
        /// </summary>
        /// <response code="200">Retorna status code 200 ok, as vagas cadastradas com ID da empresa nós últimos 30 dias.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o ID informado não existir ou não existir vagas cadastradas com esse ID nós últimos 30 dias.</response>
        [HttpGet("VagasCadastradasEm30Dias/{ID}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult VagasCadastradasEm30Dias(int ID)
        {
            var Busca = _EmpresasRepository.VagasCadastradas30Dias(ID);

            if (Busca.Count != 0)
            {
                return Ok(Busca);
            }
            else
            {
                return StatusCode(404, "Nenhuma vaga cadastrada nós últimos 30 dias com ID dessa empresa!!!");
            }
        }

       
        /// <summary>
        /// Controller responsável por buscar todos os currículos inscritos nas vagas de uma empresa nós últimos 30 dias, apartir do ID da empresa.
        /// </summary>
        /// <response code="200">Retorna status code 200 ok, todos os currículos inscritos nas vagas da empresa nós últimos 30 dias.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o ID informado não existir ou não existir currículos inscritos numa vaga nós últimos 30 dias.</response>
        [HttpGet("CurriculosRecebidosEm30Dias/{ID}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CurriculosRecebidosEm30Dias(int ID)
        {
            var Busca = _EmpresasRepository.InscricoesRecebidas30Dias(ID);

            if (Busca.Count != 0)
            {
                return Ok(Busca);
            }
            else
            {
                return StatusCode(404, "Nenhum currículo encontrado com ID dessa empresa nós ultimos 30 dias.");
            }
        }
    }
}