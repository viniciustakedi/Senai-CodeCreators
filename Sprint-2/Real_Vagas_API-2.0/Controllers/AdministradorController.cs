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
        /// Controller responsavél por criar um usuário do tipo administrador. 
        /// </summary>
        /// <response code="201">Retorna status code 201 caso for criado e usuário será criado no sistema.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso o email já estiver cadastrado no sistema.</response>   
        [HttpPost("CadastrarAdministrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CadastrarAdministrador(DbUsuarios Usuario)
        {
            var buscaEmpresa = _EmpresasRepository.BuscarPorEmpresa(Usuario.Email, "");
            var buscarUsuario = _UsuariosRepository.BuscarPorEmail(Usuario.Email);
            if (Usuario != null && buscaEmpresa == null && buscarUsuario == null && Usuario.IdTipoUsuario == 1)
            {
                _AdministradorRepository.CadastrarAdministrador(Usuario);
                return StatusCode(201, "Administrador criado com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Usuário não foi criado, email ou cpf já existente no sistema!!!");
            }
        }

        /// <summary>
        /// Controller responsavél por criar um novo usuário do tipo aluno. 
        /// </summary>
        /// <response code="201">Retorna status code 201 e usuário será criado no sistema.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o email já estiver cadastrado no sistema.</response>   
        [HttpPost("CadastrarAluno")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CadastrarAluno(DbUsuarios Usuario)
        {
            var busca = _EmpresasRepository.BuscarPorEmpresa(Usuario.Email, "");
            var buscar = _UsuariosRepository.BuscarPorEmail(Usuario.Email);
            if (Usuario != null && busca == null && buscar == null && Usuario.IdTipoUsuario == 3 || Usuario.IdTipoUsuario == 4)
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
        /// Controller responsavél por criar um novo usuário do tipo empresa.
        /// </summary>
        /// <response code="201">Retorna status code 201 usuário será criado no sistema.</response>
        /// <response code="404">Retorna status code 401 não encontrado, caso o email já estiver cadastrado no sistema.</response>   
        [HttpPost("CadastrarEmpresa")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CadastrarEmpresa(DbEmpresas Empresa)
        {
            var busca = _EmpresasRepository.BuscarPorEmpresa(Empresa.Email, Empresa.Cnpj);
            var buscar = _UsuariosRepository.BuscarPorEmail(Empresa.Email);
            if (Empresa != null && busca == null && buscar == null && Empresa.IdTipoUsuario == 2)
            {
                _AdministradorRepository.CadastrarEmpresa(Empresa);
                return StatusCode(201, "Empresa criado com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Empresa não foi criada, email ou cpf já existente no sistema!!!");
            }
        }

        /// <summary>
        /// Controller responsavél por listar todos os usuários do tipo empresa.
        /// </summary>
        /// <response code="200">Retorna status code 200 OK, listar todos os usuários do tipo empresa.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso não tiver nenhuma empresa cadastrada.</response>   
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
        /// Controller responsavél por listar todos os usuários do tipo aluno e ex-aluno.
        /// </summary>
        /// <response code="200">Retorna status code 200 OK, listar de todos os alunos cadastras.</response>
        /// <response code="404">Retorna status coide 404 não encontrado, caso não tiver nenhum aluno cadastrado.</response>   
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
        /// Controller responsavél por listar todos usuários do tipo administrador.
        /// </summary>
        /// <response code="200">Retorna status code 200 OK, listar todos os usuários do tipo administrador</response>
        /// <response code="404">Retorna status code 404 um não encontrado, caso não existe nenhum administrador cadastrado</response>   
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
        /// Controller responsavél por deletar um usuário do tipo empresa.
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="202">Retorna status code 202 aceito, caso o ID for existente, assim deletado a empresa do sistema.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o ID não for existe no sistema.</response>   
        [HttpDelete("DeletarEmpresa/{ID}")]
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
                return StatusCode(404, "Nenhuma empresa encontrada com ID informado!!!");
            }
        }

        /// <summary>
        /// Controller responsavél por deletar um usuário do tipo administrador.
        /// </summary>
        /// <response code="202">Retorna status code 202 aceito, caso o ID for existente deletado o administador do sistema.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o ID não existe no sistema.</response>   
        [HttpDelete("DeletarAdministrador/{ID}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarAdministrador(int ID)
        {
            var delete = _UsuariosRepository.BuscarPorId(ID);
            if (delete != null && delete.IdTipoUsuario == 1)
            {
                _AdministradorRepository.DeletarAdministrador(ID);
                return StatusCode(202, "Administrador deletado com sucesso!!!");
            }
            else
            {
                return StatusCode(404, "Nenhum administrador foi encontrado com ID informado!!!");
            }
        }

        /// <summary>
        /// Controller responsável por buscar uma usuário do tipo empresa apartir do cnpj ou email.
        /// </summary>
        /// <response code="200">Retorna status code 200 ok, listar os dados do usuário buscado.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o email ou cnpj informado não existir.</response>
        [HttpPost("BuscarPorEmpresa")]
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
                return StatusCode(404, "Nenhuma empresa encontrada com esse email e CNPJ!!!");
            }
        }

        /// <summary>
        /// Controller responsável por deletar uma inscrição pelo seu ID.
        /// </summary>
        /// <response code="202">Retorna status code 202 aceito, deletar a inscrição do sistema.</response>
        /// <response code="404">Retorna staus code 404 não encontrado, caso o ID informado não existir no sistema.</response>        
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api</response> 
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

                    // Retorna a resposta da requisição 202 
                    return StatusCode(202);
                }
                // Retorna a resposta da requisição 404 - Not Found
                return NotFound("Nenhuma inscrição encontrada!!!");
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
        /// Controller responsável por deletar um usuário do tipo aluno e ex-aluno.
        /// </summary>
        /// <response code="202">Retorna status code 202 aceito, deletar o usuário do sistema.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o ID informado não existir no sistema.</response>        
        /// <response code="400">Retorna stauts code 400 bad request, caso de conflito com api.</response> 
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
                return NotFound("Nenhum usuário encontrado com ID informado!!!");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400
                return BadRequest(error);
            }
        }
    }
}