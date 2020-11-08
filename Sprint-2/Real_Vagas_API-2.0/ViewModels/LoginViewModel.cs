using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "É necessário informar um email.")] //Caso o usuario tentar logar com o campo vazio
        [DataType(DataType.EmailAddress)] //Tipo email
        public string Email { get; set; } //Pegar e setar o email

        [Required(ErrorMessage = "É necessário informar uma senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
