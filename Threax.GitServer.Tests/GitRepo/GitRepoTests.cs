using AutoMapper;
using Threax.GitServer.Database;
using Threax.GitServer.InputModels;
using Threax.GitServer.Repository;
using Threax.GitServer.ViewModels;
using Threax.GitServer.Mappers;
using System;
using Threax.AspNetCore.Tests;
using Xunit;
using System.Collections.Generic;
using Threax.GitServer.Services;

namespace Threax.GitServer.Tests
{
    public static partial class GitRepoTests
    {
        private static Mockup SetupModel(this Mockup mockup)
        {
            mockup.Add<IGitRepoRepository>(m => new GitRepoRepository(m.Get<IRepoFolderProvider>()));

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

        public static void AssertEqual(GitRepoInput expected, GitRepoEntity actual)
        {
           Assert.Equal(expected.Name, actual.Name);
        }

        public static void AssertEqual(GitRepoEntity expected, GitRepo actual)
        {
           Assert.Equal(expected.ClonePath, actual.ClonePath);
        }

    }
}