using System;
using Threax.AspNetCore.Tests;
using Threax.GitServer.InputModels;
using Threax.GitServer.Repository;
using Threax.GitServer.Services;
using Threax.GitServer.ViewModels;

namespace Threax.GitServer.Tests
{
    public static partial class GitRepoTests
    {
        private static Mockup SetupModel(this Mockup mockup)
        {
            mockup.Add<IGitRepoRepository>(m => new GitRepoRepository(m.Get<IRepoFolderProvider>(), m.Get<IClonePathBuilder>(), m.Get<IProcessRunner>()));

            return mockup;
        }

        public static GitRepoInput CreateInput(String Name)
        {
            return new GitRepoInput()
            {
                Name = Name,
            };
        }

        public static GitRepo CreateView(String seed = "", String Name = default(String), String ClonePath = default(String))
        {
            return new GitRepo()
            {
                Name = Name != null ? Name : seed + Guid.NewGuid().ToString(),
                ClonePath = ClonePath != null ? ClonePath : $"ClonePath {seed}",
            };
        }

    }
}