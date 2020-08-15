using Halcyon.HAL.Attributes;
using Threax.GitServer.Controllers.Api;
using Threax.GitServer.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.GitServer.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(GitReposController), nameof(GitReposController.List))]
    [HalActionLink(typeof(GitReposController), nameof(GitReposController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(GitReposController), nameof(GitReposController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(GitReposController), nameof(GitReposController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(GitReposController), nameof(GitReposController.Add))]
    [DeclareHalLink(typeof(GitReposController), nameof(GitReposController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(GitReposController), nameof(GitReposController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(GitReposController), nameof(GitReposController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(GitReposController), nameof(GitReposController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class GitRepoCollection : PagedCollectionViewWithQuery<GitRepo, GitRepoQuery>
    {
        public GitRepoCollection(GitRepoQuery query, int total, IEnumerable<GitRepo> items) : base(query, total, items)
        {
            
        }
    }
}