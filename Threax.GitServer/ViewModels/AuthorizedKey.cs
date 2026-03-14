using Halcyon.HAL.Attributes;
using System;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.GitServer.Controllers.Api;

namespace Threax.GitServer.ViewModels 
{
    [HalModel]
    [HalSelfActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.Get))]
    [HalActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.Update))]
    [HalActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.Delete))]
    public partial class AuthorizedKey
    {
        public Guid AuthorizedKeyId { get; set; }

        public String Name { get; set; }

        public String PublicKey { get; set; }

        public bool Enabled { get; set; }

        [UiOrder(0, 2147483646)]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
