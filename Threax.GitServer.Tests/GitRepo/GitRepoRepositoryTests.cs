using Threax.GitServer.Database;
using Threax.GitServer.InputModels;
using Threax.GitServer.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Tests;
using Xunit;
using Threax.GitServer.Services;
using System.IO;

namespace Threax.GitServer.Tests
{
    public static partial class GitRepoTests
    {
        public class Repository : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();
            private String testFolder;

            public Repository()
            {
                mockup.Add<IRepoFolderProvider>(s => new RepoFolderProvider(testFolder));
            }

            public void Dispose()
            {
                mockup.Dispose();
                if (Directory.Exists(testFolder))
                {
                    Directory.Delete(testFolder, true);
                }
            }

            private void SetTestPath([System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
            {
                this.testFolder = Path.Combine(Directory.GetCurrentDirectory(), "RepoTests", memberName);
            }

            [Fact]
            async Task Add()
            {
                SetTestPath();
                var repo = mockup.Get<IGitRepoRepository>();
                var result = await repo.Add(GitRepoTests.CreateInput("TestRepo"));
                Assert.NotNull(result);
            }

            [Fact]
            async Task AddRange()
            {
                SetTestPath();
                var repo = mockup.Get<IGitRepoRepository>();
                await repo.AddRange(new GitRepoInput[] { GitRepoTests.CreateInput("TestRepo1"), GitRepoTests.CreateInput("TestRepo2"), GitRepoTests.CreateInput("TestRepo3") });
            }

            [Fact]
            async Task Delete()
            {
                SetTestPath();
                var repo = mockup.Get<IGitRepoRepository>();
                await repo.AddRange(new GitRepoInput[] { GitRepoTests.CreateInput("TestRepo1"), GitRepoTests.CreateInput("TestRepo2"), GitRepoTests.CreateInput("TestRepo3") });
                var result = await repo.Add(GitRepoTests.CreateInput("TestRepoDelete"));
                var list = await repo.List(new GitRepoQuery() { Limit = int.MaxValue });
                Assert.Equal<int>(4, list.Total);
                await repo.Delete(result.Name);
                list = await repo.List(new GitRepoQuery() { Limit = int.MaxValue });
                Assert.Equal<int>(3, list.Total);
            }

            [Fact]
            async Task Get()
            {
                SetTestPath();
                var repo = mockup.Get<IGitRepoRepository>();
                await repo.AddRange(new GitRepoInput[] { GitRepoTests.CreateInput("TestRepo1"), GitRepoTests.CreateInput("TestRepo2"), GitRepoTests.CreateInput("TestRepo3") });
                var result = await repo.Add(GitRepoTests.CreateInput("TestRepoLookup"));
                var list = await repo.List(new GitRepoQuery() { Limit = int.MaxValue });
                Assert.Equal<int>(4, list.Total);
                var getResult = await repo.Get(result.Name);
                Assert.NotNull(getResult);
            }

            [Fact]
            async Task HasGitReposEmpty()
            {
                SetTestPath();
                var repo = mockup.Get<IGitRepoRepository>();
                Assert.False(await repo.HasGitRepos());
            }

            [Fact]
            async Task HasGitRepos()
            {
                SetTestPath();
                var repo = mockup.Get<IGitRepoRepository>();
                await repo.AddRange(new GitRepoInput[] { GitRepoTests.CreateInput("TestRepo1"), GitRepoTests.CreateInput("TestRepo2"), GitRepoTests.CreateInput("TestRepo3") });
                Assert.True(await repo.HasGitRepos());
            }

            [Fact]
            async Task List()
            {
                SetTestPath();
                //This could be more complete
                var repo = mockup.Get<IGitRepoRepository>();
                await repo.AddRange(new GitRepoInput[] { GitRepoTests.CreateInput("TestRepo1"), GitRepoTests.CreateInput("TestRepo2"), GitRepoTests.CreateInput("TestRepo3") });
                var query = new GitRepoQuery();
                var result = await repo.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }
        }
    }
}