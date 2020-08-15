using Threax.GitServer.Controllers.Api;
using Threax.GitServer.InputModels;
using Threax.GitServer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Threax.GitServer.Tests
{
    public static partial class GitRepoTests
    {
        public class Controller : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Controller()
            {
                mockup.Add<GitReposController>(m => new GitReposController(m.Get<IGitRepoRepository>())
                {
                    ControllerContext = m.Get<ControllerContext>()
                });
            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            async Task List()
            {
                var totalItems = 3;

                var controller = mockup.Get<GitReposController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(GitRepoTests.CreateInput()));
                }

                var query = new GitRepoQuery();
                var result = await controller.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }

            [Fact]
            async Task Get()
            {
                var totalItems = 3;

                var controller = mockup.Get<GitReposController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(GitRepoTests.CreateInput()));
                }

                //Manually add the item we will look back up
                var lookup = await controller.Add(GitRepoTests.CreateInput());
                var result = await controller.Get(lookup.GitRepoId);
                Assert.NotNull(result);
            }

            [Fact]
            async Task Add()
            {
                var controller = mockup.Get<GitReposController>();

                var result = await controller.Add(GitRepoTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task Update()
            {
                var controller = mockup.Get<GitReposController>();

                var result = await controller.Add(GitRepoTests.CreateInput());
                Assert.NotNull(result);

                var updateResult = await controller.Update(result.GitRepoId, GitRepoTests.CreateInput());
                Assert.NotNull(updateResult);
            }

            [Fact]
            async Task Delete()
            {
                var controller = mockup.Get<GitReposController>();

                var result = await controller.Add(GitRepoTests.CreateInput());
                Assert.NotNull(result);

                var listResult = await controller.List(new GitRepoQuery());
                Assert.Equal(1, listResult.Total);

                await controller.Delete(result.GitRepoId);

                listResult = await controller.List(new GitRepoQuery());
                Assert.Equal(0, listResult.Total);
            }
        }
    }
}