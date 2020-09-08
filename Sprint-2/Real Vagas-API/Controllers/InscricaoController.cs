using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Real_Vagas_API.Controllers
{
    public class InscricaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}