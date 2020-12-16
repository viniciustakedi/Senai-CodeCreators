using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Real_Vagas_API.Domains;
using Real_Vagas_API.Interfaces;
using Real_Vagas_API.Repositories;
using Real_Vagas_API.ViewModels;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Real_Vagas_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IUsuarios _usuarios;
        public LoginController(IUsuarios usuario)
        {
            _usuarios = usuario;
        }

        /// <summary>
        /// Controller responsavél por emitir um token para verificar o usuário.
        /// </summary>
        /// <response code="200">Retorna status code 200, emitir um token de 30 minutos.</response>
        /// <response code="404">Retorna status code 404 um não encontrado, não achar nenhum usuário com aquele email e senha.</response>   
        [HttpPost] 
        public IActionResult Login(LoginViewModel Usuario)
        {
            EmpresasRepository empresa = new EmpresasRepository();
            //Puxa o método buscar por email e senha do repository
            var usuarioSelecionado1 = _usuarios.BuscarPorEmailSenha(Usuario.Email, Usuario.Senha);
            var usuarioSelecionado2 = empresa.Login(Usuario.Email, Usuario.Senha);

            if (usuarioSelecionado1 != null)
            {
                var usuarioSelecionado = usuarioSelecionado1;
                var claims = new[]
              {
                new Claim(JwtRegisteredClaimNames.Email, usuarioSelecionado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioSelecionado.Id.ToString()),
                new Claim(ClaimTypes.Role, usuarioSelecionado.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("RealVagas-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Chaves de seguranças e Tokens 
                var token = new JwtSecurityToken(
                    issuer: "RealVagas.WebApi.C#", //Emissor do Token
                    audience: "RealVagas.WebApi.C#", //Destinatário do token
                    claims: claims, //Os dados foram definidos em cima
                    expires: DateTime.Now.AddMinutes(30), //Tempo de expiração
                    signingCredentials: creds //credenciais do token
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            else if (usuarioSelecionado2 != null)
            {
                //Pay load
                //para puxar a claim mais fácil no token
                var usuarioSelecionado = usuarioSelecionado2;
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Email, usuarioSelecionado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioSelecionado.Id.ToString()),
                new Claim(ClaimTypes.Role, usuarioSelecionado.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("RealVagas-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Chaves de seguranças e Tokens 
                var token = new JwtSecurityToken(
                    issuer: "RealVagas.WebApi.C#", //Emissor do Token
                    audience: "RealVagas.WebApi.C#", //Destinatário do token
                    claims: claims, //Os dados foram definidos em cima
                    expires: DateTime.Now.AddMinutes(30), //Tempo de expiração
                    signingCredentials: creds //credenciais do token
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            else
            {
                return NotFound("Email ou senha invalidos");
            }
        }
    }
}
