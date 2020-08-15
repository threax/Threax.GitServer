using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.GitServer.InputModels;
using Threax.GitServer.ViewModels;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.GitServer.Repository
{
    public partial interface IAuthorizedKeyRepository
    {
        Task<AuthorizedKey> Add(AuthorizedKeyInput value);
        Task AddRange(IEnumerable<AuthorizedKeyInput> values);
        Task Delete(Guid id);
        Task<AuthorizedKey> Get(Guid authorizedKeyId);
        Task<bool> HasAuthorizedKeys();
        Task<AuthorizedKeyCollection> List(AuthorizedKeyQuery query);
        Task<AuthorizedKey> Update(Guid authorizedKeyId, AuthorizedKeyInput value);
    }
}