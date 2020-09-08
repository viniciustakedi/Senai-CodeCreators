using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Real_Vagas_API.ViewModels;

namespace Real_Vagas_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        private //Preciso do Repositorio
        public LoginController()
        {
            //Preciso do repositorio
        }

        public object UsuarioDomain { get; private set; }

        [HttpPost] //É um método Post
        public IActionResult Login(LoginViewModel //Preciso do repository)
        {
            UsuarioDomain usuarioselecionado = //Preciso de métodos

            if (UsuarioSelecionado == null)
            {
                return NotFound("E-mail ou senha inválidos  ");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioselecionado.Email),
                //preciso do usuario
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("RealVagas-key-auth"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Real Vagas-API",                // emissor do token
                audience: "Real Vagas-API",              // destinatário do token
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