﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.IdServerAuth;

namespace Threax.GitServer.Controllers
{
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Cookies)]
    public class AccountController : Controller
    {
        public IActionResult Relogin()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutOfIdServer();
            return View();
        }

        [HttpPost]
        public IActionResult AccessToken()
        {
            return new EmptyResult();
        }
    }
}
