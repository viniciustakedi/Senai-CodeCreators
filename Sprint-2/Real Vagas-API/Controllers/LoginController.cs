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
        private SigningCredentials creds;

        private IUsuarios _usuarios { get; set; }
        private IDados _dados { get; set; }
        public LoginController()
        {
            _usuarios = new UsuariosRepository();
            _dados = new DadosRepository();
        }


        [HttpPost] //É um método Post
        public IActionResult Login(LoginViewModel Usuario)
        {
            //Puxa o método buscar por email e senha do repository
            DbUsuarios usuarioSelecionado = _usuarios.BuscarPorEmailSenha(Usuario.Email, Usuario.Senha);

            //Verificação para ver se algum campo está vazio
            if (usuarioSelecionado == null)
            {
                return NotFound("Email ou senha invalidos");
            }


            //Pay load
            //para puxar a claim mais fácil no token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioSelecionado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioSelecionado.Id.ToString())
            };
            //Chaves de seguranças e Tokens 
            var token = new JwtSecurityToken(
                issuer: "RealVagas", //Emissor do Token
                audience: "RealVagas", //Destinatário do token
                claims: claims, //Os dados foram definidos em cima
                expires: DateTime.Now.AddMinutes(30), //Tempo de expiração
                signingCredentials: creds //credenciais do token
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
