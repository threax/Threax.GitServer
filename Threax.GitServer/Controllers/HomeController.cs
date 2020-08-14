using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Threax.ProgressiveWebApp;
using Threax.AspNetCore.Mvc.CacheUi;

namespace Threax.GitServer.Controllers
{
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Cookies)]
    public partial class HomeController : CacheUiController
    {
        public HomeController(ICacheUiBuilder builder)
            :base(builder)
        {
            
        }

        //You can get rid of this AllowAnonymous to secure the welcome page, you can secure the header and footer if desired too.
        [AllowAnonymous]
        public Task<IActionResult> Index()
        {
            return CacheUiView();
        }

        [AllowAnonymous]
        public Task<IActionResult> Header()
        {
            return CacheUiView();
        }

        [AllowAnonymous]
        public Task<IActionResult> Footer()
        {
            return CacheUiView();
        }

        //The following functions enable this site to work as a progressive web app.
        //They can be removed if you don't want this functionality.
        //This uses _LayoutTop, so you can secure the header and footer and this will still work.

        [AllowAnonymous]
        public IActionResult AppStart()
        {
            return View();
        }

        [Route("webmanifest.json")]
        [AllowAnonymous]
        public IActionResult Manifest([FromServices] IWebManifestProvider webManifestProvider)
        {
            return Json(webManifestProvider.CreateManifest(Url));
        }

        //The other view action methods are in the additional partial classes for HomeController, expand the node for
        //this class to see them.

        //If you need to declare any other view action methods manually, do that here.
    }
}
