﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Vagas_API.ViewModels
{
    public class CodigoViewModel
    {
        [Required(ErrorMessage = "É necessário informar um email")]
        public string Email { get; set; }
    }
}