using AutoMapper;
using Threax.GitServer.Database;
using Threax.GitServer.ViewModels;
using Threax.GitServer.Mappers;
using System;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Threax.GitServer.Tests
{
    public static partial class GitRepoTests
    {
        public class Profile : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Profile()
            {

            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            void InputToEntity()
            {
                var mapper = mockup.Get<AppMapper>();
                var input = GitRepoTests.CreateInput();
                var entity = mapper.MapGitRepo(input, new GitRepoEntity());

                //Make sure the id does not copy over
                Assert.Equal(default(Guid), entity.GitRepoId);
                AssertEqual(input, entity);
            }

            [Fact]
            void EntityToView()
            {
                var mapper = mockup.Get<AppMapper>();
                var entity = GitRepoTests.CreateEntity();
                var view = mapper.MapGitRepo(entity, new GitRepo());

                Assert.Equal(entity.GitRepoId, view.GitRepoId);
                AssertEqual(entity, view);
            }
        }
    }
}