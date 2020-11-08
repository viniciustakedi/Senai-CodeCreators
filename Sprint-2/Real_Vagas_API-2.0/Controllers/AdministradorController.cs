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
    [Authorize(Roles = "1")]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministrador _AdministradorRepository;
        private readonly IEmpresas _EmpresasRepository;
        private readonly IUsuarios _UsuariosRepository;
        private readonly IInscricao _InscricaosRepository;

        public AdministradorController(IAdministrador administrador, IEmpresas empresa, IUsuarios usuario, IInscricao inscricao)
        {
            _AdministradorRepository = administrador;
            _EmpresasRepository = empresa;
            _InscricaosRepository = inscricao;
            _UsuariosRepository = usuario;
        }

        /// <summary>
        /// Controller responsavél por criar um novo administrador. 
        /// </summary>
        /// <response code="201">Retorna um criado e usuário será criado no sistemas.</response>
        /// <response code="404">Retorna um não encontrado caso o email já estiver cadastrado no sistemas.</response>   
        [HttpPost("CadastrarAdministrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CadastrarAdministrador(DbUsuarios Usuario)
        {
            var buscaEmpresa = _EmpresasRepository.SearchByEmpresa(Usuario.Email, "");
            var buscarUsuario = _UsuariosRepository.BuscarPorEmail(Usuario.Email);
            if (buscaEmpresa == null && buscarUsuario == null && Usuario.IdTipoUsuario == 1)
            {
                _AdministradorRepository.CadastrarAdm(Usuario);
                return StatusCode(201, "Administrador criado com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Usuário não foi criado, email ou cpf já existente no sistema!!!");
            }
        }

        /// <summary>
        /// Controller responsavél por criar um novo aluno no banco de dados. 
        /// </summary>
        /// <response code="201">Retorna um criado e usuário será criado no sistemas.</response>
        /// <response code="404">Retorna um não encontrado caso o email já estiver cadastrado no sistemas.</response>   
        [HttpPost("CadastrarAluno")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CadastrarAluno(DbUsuarios Usuario)
        {
            var busca = _EmpresasRepository.SearchByEmpresa(Usuario.Email, "");
            var buscar = _UsuariosRepository.BuscarPorEmail(Usuario.Email);
            if (busca == null && buscar == null && Usuario.IdTipoUsuario == 3 || Usuario.IdTipoUsuario == 4)
            {
                _AdministradorRepository.CadastrarAluno(Usuario);
                return StatusCode(201, "Aluno criado com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Usuário não foi criado, email ou cpf já existente no sistema!!!");
            }
        }

        /// <summary>
        /// Controller responsavél por criar um nova empresa no banco de dados. 
        /// </summary>
        /// <response code="201">Retorna um criado e usuário será criado no sistemas.</response>
        /// <response code="404">Retorna um não encontrado caso o email já estiver cadastrado no sistemas.</response>   
        [HttpPost("CadastrarEmpresa")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CadastrarEmpresa(DbEmpresas Empresa)
        {
            var busca = _EmpresasRepository.SearchByEmpresa(Empresa.Email, Empresa.Cnpj);
            var buscar = _UsuariosRepository.BuscarPorEmail(Empresa.Email);
            if (busca == null && buscar == null && Empresa.IdTipoUsuarioNavigation.Id == 2)
            {
                _AdministradorRepository.CadastrarEmpresa(Empresa);
                return StatusCode(201, "Empresa criado com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Empresa não foi criado, email ou cpf já existente no sistema!!!");
            }
        }

        /// <summary>
        /// Controller responsavél listar todas as empresas no sistema.
        /// </summary>
        /// <response code="200">Retorna OK, listar de todas empresas cadastras.</response>
        /// <response code="404">Retorna um não encontrado, caso não tiver nenhuma empresa cadastrada.</response>   
        [HttpGet("ListarEmpresas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarEmpresas()
        {
            var empresas = _AdministradorRepository.ListarEmpresas();
            if (empresas.Count != 0)
            {
                return StatusCode(200, empresas);
            }
            else
            {
                return StatusCode(404, "Nenhuma empresa encontrada no sistema!!!");
            }
        }

        /// <summary>
        /// Controller responsavél listar todos os alunos no sistema.
        /// </summary>
        /// <response code="200">Retorna OK, listar de todos os alunos cadastras.</response>
        /// <response code="404">Retorna um não encontrado, caso não tiver nenhum aluno cadastrado.</response>   
        [HttpGet("ListarAluno")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarAluno()
        {
            var alunos = _AdministradorRepository.ListarAlunos();
            if (alunos.Count != 0)
            {
                return StatusCode(200, alunos);
            }
            else
            {
                return StatusCode(404, "Nenhum aluno encontrado no sistema!!!");
            }
        }

        /// <summary>
        /// Controller responsavél listar todos os adminstradores no sistema.
        /// </summary>
        /// <response code="200">Retorna OK, listar de todos os adminstradores cadastras.</response>
        /// <response code="404">Retorna um não encontrado, adminstradores caso não tiver nenhum aluno cadastrado.</response>   
        [HttpGet("ListarAdministrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarAdministrador()
        {
            var Administradores = _AdministradorRepository.ListarAdministradores();
            if (Administradores.Count != 0)
            {
                return StatusCode(200, Administradores);
            }
            else
            {
                return StatusCode(404, "Nenhum administrador encontrado no sistema!!!");
            }
        }

        /// <summary>
        /// Controller para deletar uma empresa do banco de dados
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="202">Retorna um aceito caso o ID for existente, assim deletado a empresa do sistema.</response>
        /// <response code="404">Retorna um não encontrado caso o ID não existe no sistema.</response>   
        [HttpDelete("DeletarEmpresa/{ID}")]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarEmpresa(int ID)
        {
            var delete = _EmpresasRepository.SearchById(ID);
            if (delete != null)
            {
                _EmpresasRepository.Delete(ID);
                return StatusCode(202, "Empresa deletada do bancos de dados com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Empresa não encontrada com esse ID informado!!!");
            }
        }

        /// <summary>
        /// Controller para deletar um administador do banco de dados
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="202">Retorna um aceito caso o ID for existente, assim deletado o administador do sistema.</response>
        /// <response code="404">Retorna um não encontrado caso o ID não existe no sistema.</response>   
        [HttpDelete("DeletarAdministrador/{ID}")]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarAdministrador(int ID)
        {
            var delete = _UsuariosRepository.BuscarPorId(ID);
            if (delete != null && delete.IdTipoUsuario == 1)
            {
                _AdministradorRepository.DeletarAdm(ID);
                return StatusCode(202, "Administrador deletado do bancos de dados com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Administrador não encontrado com esse ID informado!!!");
            }
        }

        /// <summary>
        /// Controller responsável por buscar dados do banco de dados apartir do email ou cnpj.
        /// </summary>
        /// <response code="200">Retorna um ok, os dados e as informadas da empresa buscada. </response>
        /// <response code="404">Retorna não encontrado caso o email ou cnpj informado não estiver cadastrados.</response>
        [HttpGet("BuscarPorEmpresa")]
        [Authorize(Roles = "1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPorEmpresa(DbEmpresas Empresa)
        {
            var Busca = _EmpresasRepository.SearchByEmpresa(Empresa.Email, Empresa.Cnpj);

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
        /// Deletar um inscrição pelo ID
        /// </summary>
        /// <response code="202">Retorna um aceiteo, e deletar a inscrição do sistemas.</response>
        /// <response code="404">Retorna bad request em caso de problemas na API.</response> 
        /// <response code="400">Retorna não encontrado caso o ID informado não estiver cadastrado.</response>        
        [HttpDelete("DeletarInscricao/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletarInscricao(int id)
        {
            try
            {
                DbInscricao inscriçãoBuscado = _InscricaosRepository.BuscarPorId(id);

                if (inscriçãoBuscado != null)
                {
                    // Faz a chamada para o método
                    _InscricaosRepository.Deletar(id);

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
        /// Deleta um usuário pelo id do sistema
        /// </summary>
        /// <response code="202">Retorna um aceito, deletar o usuário do sistema.</response>
        /// <response code="404">Retorna bad request em caso de problemas na API.</response> 
        /// <response code="400">Retorna não encontrado caso o ID informado não estiver cadastrado.</response>        
        [HttpDelete("DeletarUsuario/{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                DbUsuarios usuario = _UsuariosRepository.BuscarPorId(id);

                if (usuario != null)
                {
                    // Faz a chamada para o método
                    _UsuariosRepository.Deletar(id);

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
        }
    }
}