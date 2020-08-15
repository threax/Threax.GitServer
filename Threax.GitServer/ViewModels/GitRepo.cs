using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Threax.GitServer.Controllers.Api;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Threax.GitServer.ViewModels 
{
    [HalModel]
    [HalSelfActionLink(typeof(GitReposController), nameof(GitReposController.Get))]
    [HalActionLink(typeof(GitReposController), nameof(GitReposController.Delete))]
    public partial class GitRepo : ICreatedModified
    {
        public String Name { get; set; }

        public String ClonePath { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
