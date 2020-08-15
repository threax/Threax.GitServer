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

        [HttpGet("{Name}")]
        [HalRel(CrudRels.Get)]
        public async Task<GitRepo> Get(String name)
        {
            return await repo.Get(name);
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new gitRepo")]
        public async Task<GitRepo> Add([FromBody]GitRepoInput gitRepo)
        {
            return await repo.Add(gitRepo);
        }

        [HttpDelete("{Name}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(String name)
        {
            await repo.Delete(name);
        }
    }
}