using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Threax.GitServer.Controllers
{
    public partial class HomeController
    {
        public IActionResult GitRepos()
        {
            return View();
        }
    }
}