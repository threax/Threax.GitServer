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
    [HalSelfActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.List))]
    [HalActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.Add))]
    [DeclareHalLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(AuthorizedKeysController), nameof(AuthorizedKeysController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class AuthorizedKeyCollection : PagedCollectionViewWithQuery<AuthorizedKey, AuthorizedKeyQuery>
    {
        public AuthorizedKeyCollection(AuthorizedKeyQuery query, int total, IEnumerable<AuthorizedKey> items) : base(query, total, items)
        {
            
        }
    }
}