using System.Collections.Generic;
using System.Threading.Tasks;
using Threax.GitServer.InputModels;
using Threax.GitServer.ViewModels;

namespace Threax.GitServer.Repository
{
    public interface IGitRepoRepository
    {
        Task<GitRepo> Add(GitRepoInput gitRepo);
        Task AddRange(IEnumerable<GitRepoInput> gitRepos);
        Task Delete(string name);
        Task<GitRepo> Get(string name);
        Task<bool> HasGitRepos();
        Task<GitRepoCollection> List(GitRepoQuery query);
    }
}