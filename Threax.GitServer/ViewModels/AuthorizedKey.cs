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
    [HalSelfActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.Get))]
    [HalActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.Update))]
    [HalActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.Delete))]
    public partial class AuthorizedKey : ICreatedModified
    {
        public Guid AuthorizedKeyId { get; set; }

        public String Name { get; set; }

        public String PublicKey { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
