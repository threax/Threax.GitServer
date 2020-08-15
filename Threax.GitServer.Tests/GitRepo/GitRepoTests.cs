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

namespace Threax.GitServer.Tests
{
    public static partial class GitRepoTests
    {
        private static Mockup SetupModel(this Mockup mockup)
        {
            mockup.Add<IGitRepoRepository>(m => new GitRepoRepository(m.Get<AppDbContext>(), m.Get<AppMapper>()));

            return mockup;
        }

        public static GitRepoInput CreateInput(String seed = "", String Name = default(String), String ClonePath = default(String))
        {
            return new GitRepoInput()
            {
                Name = Name != null ? Name : $"Name {seed}",
                ClonePath = ClonePath != null ? ClonePath : $"ClonePath {seed}",
            };
        }

        public static GitRepoEntity CreateEntity(String seed = "", Guid? GitRepoId = default(Guid?), String Name = default(String), String ClonePath = default(String))
        {
            return new GitRepoEntity()
            {
                GitRepoId = GitRepoId.HasValue ? GitRepoId.Value : Guid.NewGuid(),
                Name = Name != null ? Name : $"Name {seed}",
                ClonePath = ClonePath != null ? ClonePath : $"ClonePath {seed}",
            };
        }

        public static GitRepo CreateView(String seed = "", Guid? GitRepoId = default(Guid?), String Name = default(String), String ClonePath = default(String))
        {
            return new GitRepo()
            {
                GitRepoId = GitRepoId.HasValue ? GitRepoId.Value : Guid.NewGuid(),
                Name = Name != null ? Name : $"Name {seed}",
                ClonePath = ClonePath != null ? ClonePath : $"ClonePath {seed}",
            };
        }

        public static void AssertEqual(GitRepoInput expected, GitRepoEntity actual)
        {
           Assert.Equal(expected.Name, actual.Name);
           Assert.Equal(expected.ClonePath, actual.ClonePath);
        }

        public static void AssertEqual(GitRepoEntity expected, GitRepo actual)
        {
           Assert.Equal(expected.Name, actual.Name);
           Assert.Equal(expected.ClonePath, actual.ClonePath);
        }

    }
}