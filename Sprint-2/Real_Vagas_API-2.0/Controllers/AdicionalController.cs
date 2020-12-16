using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class AdicionalController : ControllerBase
    {
        private readonly IAdicional _BaseRepository;

        public AdicionalController(IAdicional Base)
        {
            _BaseRepository = Base;
        }

        /// <summary>
        /// Controller responsável por enviar um codigo para redefinir a senha para email para quem solicitou.
        /// </summary>
        /// <response code="200">Retorna status code 200 ok, enviar um codigo para email da pessoa.</response>
        /// <response code="404">Retorna status code 404 não encontrado, caso o email solicitado não existir no sistema.</response>
        [HttpGet("SolicitarCodigo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SolicitarCodigo(CodigoViewModel email)
        {
            UsuariosRepository repository = new UsuariosRepository();
            DbEmpresas Empresa = _BaseRepository.BuscarPorEmpresa(email.Email, "");
            DbUsuarios usuario = repository.BuscarPorEmail(email.Email);


            if (Empresa != null)
            {
                _BaseRepository.EnviarEmail(email.Email, Empresa.Id, Empresa.Senha);
                return Ok("Email enviado com sucesso, verifique sua caixa de email para redefinir sua senha!!!");
            }
            else if (usuario != null)
            {
                _BaseRepository.EnviarEmail(usuario.Email, usuario.Id, usuario.IdDadosNavigation.Senha);
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
        /// <response code="200">Retorna status code 200 ok, redefinir a senha do usuário.</response>
        /// <response code="404">Retorna status code 404 não autorizado, caso o codigo tenha expirado.</response>
        [HttpPut("RedefinirSenha")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult RedefinirSenha(RedefinirViewModel redefinir)
        {
            string clear = _BaseRepository.ValidarCodigo(redefinir.codigo);
            string Empresa = "";
            if (clear != "")
            {
                Empresa = _BaseRepository.ModifyPass(clear, redefinir.NovaSenha);
            }

            if (Empresa != "Não autenticado")
            {
                return Ok("sua senha foi redefinida com sucesso!!!");
            }
            else
            {
                return NotFound("Seu codigo expirou solicite outro para redefinir sua senha!!!");
            }
        }
    }
}