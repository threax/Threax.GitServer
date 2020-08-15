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
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class GitReposController : Controller
    {
        private IGitRepoRepository repo;

        public GitReposController(IGitRepoRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<GitRepoCollection> List([FromQuery] GitRepoQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{GitRepoId}")]
        [HalRel(CrudRels.Get)]
        public async Task<GitRepo> Get(Guid gitRepoId)
        {
            return await repo.Get(gitRepoId);
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new gitRepo")]
        public async Task<GitRepo> Add([FromBody]GitRepoInput gitRepo)
        {
            return await repo.Add(gitRepo);
        }

        [HttpPut("{GitRepoId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update gitRepo")]
        public async Task<GitRepo> Update(Guid gitRepoId, [FromBody]GitRepoInput gitRepo)
        {
            return await repo.Update(gitRepoId, gitRepo);
        }

        [HttpDelete("{GitRepoId}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(Guid gitRepoId)
        {
            await repo.Delete(gitRepoId);
        }
    }
}