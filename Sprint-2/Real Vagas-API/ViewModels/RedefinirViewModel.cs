using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.ViewModels
{
    public class RedefinirViewModel
    {
        [Required(ErrorMessage = "É necessário informar um código")]
        public string codigo { get; set; }
        [Required(ErrorMessage = "É necessário informar uma nova senha")]
        public string NovaSenha { get; set; }

    }
}
