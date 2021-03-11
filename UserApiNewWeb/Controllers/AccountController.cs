using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApiNewWeb.Models;

namespace UserApiNewWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("api/register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {

            return Ok(register);
        }
    }
}
