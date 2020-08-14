using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.GitServer.Controllers.Api;

namespace Threax.GitServer.ViewModels
{
    [HalActionLink(typeof(ValuesController), nameof(ValuesController.List), "ListValues")]
    [HalActionLink(typeof(ValuesController), nameof(ValuesController.Add), "AddValue")]
    public partial class EntryPoint
    {
        
    }
}