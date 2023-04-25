using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentroAutomotivo.Controllers
{
    [Authorize]
    public class MeusVeiculosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}