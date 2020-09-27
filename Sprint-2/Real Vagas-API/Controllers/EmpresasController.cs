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
        /// Controller para deletar uma empresa do banco de dados
        /// </summary>
        /// <param name="ID"></param>
        /// <response code="202">Retorna um aceito caso o ID for existente, assim deletado a empresa do sistema.</response>
        /// <response code="404">Retorna um não encontrado caso o ID não existe no sistema.</response>   
        [HttpDelete("{ID}")]
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
        /// Controller responsável por listar todas as empresas do sistemas.
        /// </summary>
        /// <response code="200">Retorna um OK com uma lista de empresas cadastradas. </response>
        /// <response code="404">Retorna um não encontrado caso não existe empresas cadastradas.</response>
        [HttpGet]
        [Authorize(Roles = "1")]
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
        /// <response code="201">Retorna que foi criado a empresa, assim cadastrado a empresa no banco de dados. </response>
        /// <response code="400">Retorna sintaxe inválida caso cnpj ou email já estiver cadastrado no sistema.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastraEmpresa(DbEmpresas Empresa)
        {
            UsuariosRepository Usuario = new UsuariosRepository();
            var busca = _EmpresasRepository.SearchByEmpresa(Empresa.Email, Empresa.Cnpj);
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
        /// <response code="200">Retorna um ok, os dados serão atualizados no banco de dados. </response>
        /// <response code="404">Retorna não encontrado caso o ID informado não existir.</response>
        [HttpPut]
        [Authorize(Roles = "2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizarEmpresa(DbEmpresas Empresa)
        {
            var Busca = _EmpresasRepository.SearchById(Empresa.Id);

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
        /// Controller responsável por buscar dados do banco de dados apartir do ID da empresa.
        /// </summary>
        /// <response code="200">Retorna um ok, os dados e as informadas da empresa buscada pelo ID. </response>
        /// <response code="404">Retorna não encontrado caso o ID informado não existir.</response>
        [HttpGet("BuscarPeloID/{ID}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPeloID(int ID)
        {
            var Busca = _EmpresasRepository.SearchById(ID);

            if (Busca != null)
            {
                return Ok(Busca);
            }
            else
            {
                return StatusCode(404, "Nenhuma empresa encontrada com esse ID!!!");
            }
        }

        /// <summary>
        /// Controller responsável por buscar todas as vagas cadastradas por uma empresa, apartir do ID da empresa.
        /// </summary>
        /// <response code="200">Retorna um ok, as vagas cadastradas com ID da empresa.</response>
        /// <response code="404">Retorna não encontrado caso o ID informado não existir ou não existir vagas com esse ID.</response>
        [HttpGet("VagasCadastradas/{ID}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult VagasCadastradas(int ID)
        {
            var Busca = _EmpresasRepository.RegisteredVacancies(ID);

            if (Busca.Count != 0)
            {
                return Ok(Busca);
            }
            else
            {
                return StatusCode(404, "Nenhuma vaga encontrada com ID dessa empresa!!!");
            }
        }

        /// <summary>
        /// Controller responsável por buscar todas as vagas cadastradas nós últimos 30 dias por uma empresa, apartir do ID da empresa.
        /// </summary>
        /// <response code="200">Retorna um ok, as vagas cadastradas com ID da empresa nós últimos 30 dias.</response>
        /// <response code="404">Retorna não encontrado caso o ID informado não existir ou não existir vagas cadastradas com esse ID nós últimos 30 dias.</response>
        [HttpGet("VagasCadastradasEm30Dias/{ID}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult VagasCadastradasEm30Dias(int ID)
        {
            var Busca = _EmpresasRepository.RegisteredVacanciesBy30Days(ID);

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
        /// Controller responsável por buscar todos os currículos inscritos nas vagas de uma empresa, apartir do ID da empresa.
        /// </summary>
        /// <response code="200">Retorna um ok, todos os currículos inscritos nas vagas da empresa.</response>
        /// <response code="404">Retorna não encontrado caso o ID informado não existir ou não existir currículos inscritos numa vaga.</response>
        [HttpGet("CurriculosRecebidos/{ID}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CurriculosRecebidos(int ID)
        {
            var Busca = _EmpresasRepository.ResumesReceived(ID);

            if (Busca.Count != 0)
            {
                return Ok(Busca);
            }
            else
            {
                return StatusCode(404, "Nenhum currículo encontrado com ID dessa empresa");
            }
        }

        /// <summary>
        /// Controller responsável por buscar todos os currículos inscritos nas vagas de uma empresa nós últimos 30 dias, apartir do ID da empresa.
        /// </summary>
        /// <response code="200">Retorna um ok, todos os currículos inscritos nas vagas da empresa nós últimos 30 dias.</response>
        /// <response code="404">Retorna não encontrado caso o ID informado não existir ou não existir currículos inscritos numa vaga nós últimos 30 dias.</response>
        [HttpGet("CurriculosRecebidosEm30Dias/{ID}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CurriculosRecebidosEm30Dias(int ID)
        {
            var Busca = _EmpresasRepository.ResumesReceivedBy30Days(ID);

            if (Busca.Count != 0)
            {
                return Ok(Busca);
            }
            else
            {
                return StatusCode(404, "Nenhum currículo encontrado com ID dessa empresa nós ultimos 30 dias.");
            }
        }

        /// <summary>
        /// Controller responsável por buscar todos os currículos inscritos numa vaga, apartir do ID da vaga.
        /// </summary>
        /// <response code="200">Retorna um ok, todos os currículos inscritos na vaga selecionada.</response>
        /// <response code="404">Retorna não encontrado caso o ID informado não existir ou não existir currículos inscritos na vaga.</response>
        [HttpGet("CurriculosRecebidosPorVagas/{ID}")]
        [Authorize(Roles = "1,2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CurriculosRecebidosPorVagas(int ID)
        {
            var Busca = _EmpresasRepository.ResumesReceivedByVacancies(ID);

            if (Busca.Count != 0)
            {
                return Ok(Busca);
            }
            else
            {
                return StatusCode(404, "Nenhum currículo encontrado com ID dessa vaga.");
            }
        }

        /// <summary>
        /// Controller responsável por buscar CNPJ ou CPF através de um web crawler para consulta se é válido.
        /// </summary>
        /// <response code="200">Retorna um ok, e a situação do CPF ou CNPJ.</response>
        /// <response code="404">Retorna não encontrado caso o CPF ou CNPJ for inválido.</response>
        [HttpGet("validarcnpj")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult validar(ValidarViewModel codigo)
        {
            string ret = _EmpresasRepository.VerificarCnpjOuCpf(codigo.validador);

            if (ret != "CPF ou CNPJ não foi encontrado!!!" || ret != "Tente novamente!" && ret.Substring(0, 36) == "O CPF consultado a Situação: Regular" || ret.Substring(0, 35) == "O CNPJ consultado a Situação: Ativa")
            {
                return Ok(ret);
            }
            else
            {
                return NotFound(ret);
            }
        }

        /// <summary>
        /// Controller responsável por enviar um codigo para redefinir a senha para email para quem solicitou.
        /// </summary>
        /// <response code="200">Retorna um ok, enviar um codigo para email da pessoa.</response>
        /// <response code="404">Retorna não encontrado caso email não existe no sistema.</response>
        [HttpGet("SolicitarCodigo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SolicitarCodigo(CodigoViewModel email)
        {
            UsuariosRepository repository = new UsuariosRepository();
            DbEmpresas Empresa = _EmpresasRepository.SearchByEmpresa(email.Email, "");
            DbUsuarios usuario = repository.BuscarPorEmail(email.Email);


            if (Empresa != null)
            {
                _EmpresasRepository.EnviarEmail(email.Email, Empresa.Id, Empresa.Senha);
                return Ok("Email enviado com sucesso, verifique sua caixa de email para redefinir sua senha!!!");
            }else if (usuario != null)
            {
                _EmpresasRepository.EnviarEmail(usuario.Email, usuario.Id, usuario.IdDadosNavigation.Senha);
                return Ok("Email enviado com sucesso, verifique sua caixa de email para redefinir sua senha!!!");
            }
            else
            {
                return NotFound("Email não cadastrado no sistema!!!");
            }
        }

        /// <summary>
        /// Controller responsável por redefinir a senha do usuário através do codigo enviado para email da pessoa.
        /// </summary>
        /// <response code="200">Retorna um ok, redefinir a senha do usuário.</response>
        /// <response code="404">Retorna não autorizado caso o codigo tenha expirado.</response>
        [HttpPut("RedefinirSenha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult RedefinirSenha(RedefinirViewModel redefinir)
        {
            string clear = _EmpresasRepository.ValidateCode(redefinir.codigo);
            string Empresa = "";
            if (clear != "")
            {
                Empresa = _EmpresasRepository.ModifyPass(clear, redefinir.NovaSenha);
            }

            if (Empresa != "Não autenticado")
            {
                return Ok("sua senha foi redefinida com sucesso!!!");
            }
            else
            {
                return Unauthorized("Seu codigo expirou solicite outro para redefinir sua senha!!!");
            }
        }
    }
}