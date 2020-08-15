using Threax.GitServer.Controllers.Api;
using Threax.GitServer.InputModels;
using Threax.GitServer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Threax.AspNetCore.Tests;
using Xunit;
using Threax.GitServer.Services;
using System.IO;

namespace Threax.GitServer.Tests
{
    public static partial class GitRepoTests
    {
        public class Controller : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();
            private String testFolder;

            public Controller()
            {
                mockup.Add<IRepoFolderProvider>(s => new RepoFolderProvider(testFolder));
                mockup.Add<GitReposController>(m => new GitReposController(m.Get<IGitRepoRepository>())
                {
                    ControllerContext = m.Get<ControllerContext>()
                });
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
                this.testFolder = Path.Combine(Directory.GetCurrentDirectory(), "ControllerTests", memberName);
            }

            [Fact]
            async Task List()
            {
                SetTestPath();
                var totalItems = 3;

                var controller = mockup.Get<GitReposController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(GitRepoTests.CreateInput($"Repo{i}")));
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
                SetTestPath();
                var totalItems = 3;

                var controller = mockup.Get<GitReposController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(GitRepoTests.CreateInput($"Repo{i}")));
                }

                //Manually add the item we will look back up
                var lookup = await controller.Add(GitRepoTests.CreateInput($"RepoLookup"));
                var result = await controller.Get(lookup.Name);
                Assert.NotNull(result);
            }

            [Fact]
            async Task Add()
            {
                SetTestPath();
                var controller = mockup.Get<GitReposController>();

                var result = await controller.Add(GitRepoTests.CreateInput("TestRepo"));
                Assert.NotNull(result);
            }

            [Fact]
            async Task Delete()
            {
                SetTestPath();
                var controller = mockup.Get<GitReposController>();

                var result = await controller.Add(GitRepoTests.CreateInput("TestRepo"));
                Assert.NotNull(result);

                var listResult = await controller.List(new GitRepoQuery());
                Assert.Equal(1, listResult.Total);

                await controller.Delete(result.Name);

                listResult = await controller.List(new GitRepoQuery());
                Assert.Equal(0, listResult.Total);
            }
        }
    }
}