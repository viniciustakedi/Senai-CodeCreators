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

namespace Real_Vagas_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
  
    public class LoginController : ControllerBase
    {
        private IUsuarios _usuarios { get; set; }
        public LoginController()
        {
            _usuarios = new UsuariosRepository();
        }

        [HttpPost] //É um método Post
        public IActionResult Login(LoginViewModel Usuario)
        {
            DbUsuarios usuarioselecionado = _usuarios.BuscarPorEmailSenha(Usuario.Email, Usuario.Senha);

            if (usuarioselecionado == null)
            {
                return NotFound("E-mail ou senha inválidos  ");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioselecionado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioselecionado.IdDbUsuarios.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("RealVagas-key-auth"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "RealVagas",                // emissor do token
                audience: "RealVagas",              // destinatário do token
                claims: claims,                          // dados definidos acima
                expires: DateTime.Now.AddMinutes(60),    // tempo de expiração
                signingCredentials: creds                // credenciais do token
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}