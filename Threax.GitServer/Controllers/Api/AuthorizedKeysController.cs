using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Threax.GitServer.Repository;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.GitServer.ViewModels;
using Threax.GitServer.InputModels;
using Microsoft.AspNetCore.Authorization;
using Threax.GitServer.Services;

namespace Threax.GitServer.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer, Roles = Roles.EditAuthorizedKeys)]
    public partial class AuthorizedKeysController : Controller
    {
        private IAuthorizedKeyRepository repo;
        private readonly IAuthorizedKeysWriter authorizedKeysWriter;

        public AuthorizedKeysController(IAuthorizedKeyRepository repo, IAuthorizedKeysWriter authorizedKeysWriter)
        {
            this.repo = repo;
            this.authorizedKeysWriter = authorizedKeysWriter;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<AuthorizedKeyCollection> List([FromQuery] AuthorizedKeyQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{AuthorizedKeyId}")]
        [HalRel(CrudRels.Get)]
        public async Task<AuthorizedKey> Get(Guid authorizedKeyId)
        {
            return await repo.Get(authorizedKeyId);
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new authorizedKey")]
        public async Task<AuthorizedKey> Add([FromBody]AuthorizedKeyInput authorizedKey)
        {
            var results = await repo.Add(authorizedKey);
            await WriteAuthorizationKeys();
            return results;
        }

        [HttpPut("{AuthorizedKeyId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update authorizedKey")]
        public async Task<AuthorizedKey> Update(Guid authorizedKeyId, [FromBody]AuthorizedKeyInput authorizedKey)
        {
            var results = await repo.Update(authorizedKeyId, authorizedKey);
            await WriteAuthorizationKeys();
            return results;
        }

        [HttpDelete("{AuthorizedKeyId}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(Guid authorizedKeyId)
        {
            await repo.Delete(authorizedKeyId);
            await WriteAuthorizationKeys();
        }

        private async Task WriteAuthorizationKeys()
        {
            var activeKeys = await repo.GetAllEnabledPublicKeys();
            authorizedKeysWriter.WriteAuthorizedKeys(activeKeys);
        }
    }
}