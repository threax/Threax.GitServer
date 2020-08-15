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

namespace Threax.GitServer.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer, Roles = Roles.EditAuthorizedKeys)]
    public partial class AuthorizedKeysController : Controller
    {
        private IAuthorizedKeyRepository repo;

        public AuthorizedKeysController(IAuthorizedKeyRepository repo)
        {
            this.repo = repo;
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
            return await repo.Add(authorizedKey);
        }

        [HttpPut("{AuthorizedKeyId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update authorizedKey")]
        public async Task<AuthorizedKey> Update(Guid authorizedKeyId, [FromBody]AuthorizedKeyInput authorizedKey)
        {
            return await repo.Update(authorizedKeyId, authorizedKey);
        }

        [HttpDelete("{AuthorizedKeyId}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(Guid authorizedKeyId)
        {
            await repo.Delete(authorizedKeyId);
        }
    }
}