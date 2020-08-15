using Threax.GitServer.Database;
using Threax.GitServer.InputModels;
using Threax.GitServer.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Threax.GitServer.Tests
{
    public static partial class GitRepoTests
    {
        public class Repository : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Repository()
            {

            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            async Task Add()
            {
                var repo = mockup.Get<IGitRepoRepository>();
                var result = await repo.Add(GitRepoTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task AddRange()
            {
                var repo = mockup.Get<IGitRepoRepository>();
                await repo.AddRange(new GitRepoInput[] { GitRepoTests.CreateInput(), GitRepoTests.CreateInput(), GitRepoTests.CreateInput() });
            }

            [Fact]
            async Task Delete()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<IGitRepoRepository>();
                await repo.AddRange(new GitRepoInput[] { GitRepoTests.CreateInput(), GitRepoTests.CreateInput(), GitRepoTests.CreateInput() });
                var result = await repo.Add(GitRepoTests.CreateInput());
                Assert.Equal<int>(4, dbContext.GitRepos.Count());
                await repo.Delete(result.GitRepoId);
                Assert.Equal<int>(3, dbContext.GitRepos.Count());
            }

            [Fact]
            async Task Get()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<IGitRepoRepository>();
                await repo.AddRange(new GitRepoInput[] { GitRepoTests.CreateInput(), GitRepoTests.CreateInput(), GitRepoTests.CreateInput() });
                var result = await repo.Add(GitRepoTests.CreateInput());
                Assert.Equal<int>(4, dbContext.GitRepos.Count());
                var getResult = await repo.Get(result.GitRepoId);
                Assert.NotNull(getResult);
            }

            [Fact]
            async Task HasGitReposEmpty()
            {
                var repo = mockup.Get<IGitRepoRepository>();
                Assert.False(await repo.HasGitRepos());
            }

            [Fact]
            async Task HasGitRepos()
            {
                var repo = mockup.Get<IGitRepoRepository>();
                await repo.AddRange(new GitRepoInput[] { GitRepoTests.CreateInput(), GitRepoTests.CreateInput(), GitRepoTests.CreateInput() });
                Assert.True(await repo.HasGitRepos());
            }

            [Fact]
            async Task List()
            {
                //This could be more complete
                var repo = mockup.Get<IGitRepoRepository>();
                await repo.AddRange(new GitRepoInput[] { GitRepoTests.CreateInput(), GitRepoTests.CreateInput(), GitRepoTests.CreateInput() });
                var query = new GitRepoQuery();
                var result = await repo.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }

            [Fact]
            async Task Update()
            {
                var repo = mockup.Get<IGitRepoRepository>();
                var result = await repo.Add(GitRepoTests.CreateInput());
                Assert.NotNull(result);
                var updateResult = await repo.Update(result.GitRepoId, GitRepoTests.CreateInput());
                Assert.NotNull(updateResult);
            }
        }
    }
}