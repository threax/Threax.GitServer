using Halcyon.HAL.Attributes;
using System;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.GitServer.Controllers.Api;

namespace Threax.GitServer.ViewModels 
{
    [HalModel]
    [HalSelfActionLink(typeof(GitReposController), nameof(GitReposController.Get))]
    [HalActionLink(typeof(GitReposController), nameof(GitReposController.Delete))]
    public partial class GitRepo
    {
        public String Name { get; set; }

        public String ClonePath { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
