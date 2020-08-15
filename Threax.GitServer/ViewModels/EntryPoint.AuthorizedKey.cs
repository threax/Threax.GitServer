using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.GitServer.Controllers.Api;

namespace Threax.GitServer.ViewModels
{
    [HalActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.List), "ListAuthorizedKeys")]
    [HalActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.Add), "AddAuthorizedKey")]
    public partial class EntryPoint
    {
        
    }
}