using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.GitServer.Controllers.Api;

namespace Threax.GitServer.ViewModels
{
    [HalActionLink(typeof(GitReposController), nameof(GitReposController.List), "ListGitRepos")]
    [HalActionLink(typeof(GitReposController), nameof(GitReposController.Add), "AddGitRepo")]
    public partial class EntryPoint
    {
        
    }
}