using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.GitServer.InputModels;
using Threax.GitServer.ViewModels;
using Threax.AspNetCore.Halcyon.Ext;

namespace Threax.GitServer.Repository
{
    public partial interface IGitRepoRepository
    {
        Task<GitRepo> Add(GitRepoInput value);
        Task AddRange(IEnumerable<GitRepoInput> values);
        Task Delete(Guid id);
        Task<GitRepo> Get(Guid gitRepoId);
        Task<bool> HasGitRepos();
        Task<GitRepoCollection> List(GitRepoQuery query);
        Task<GitRepo> Update(Guid gitRepoId, GitRepoInput value);
    }
}