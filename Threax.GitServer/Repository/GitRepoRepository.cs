using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Threax.GitServer.Database;
using Threax.GitServer.InputModels;
using Threax.GitServer.ViewModels;
using Threax.GitServer.Mappers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using System.IO;
using Threax.GitServer.Services;

namespace Threax.GitServer.Repository
{
    public partial class GitRepoRepository : IGitRepoRepository
    {
        private readonly IRepoFolderProvider repoFolderProvider;

        public GitRepoRepository(IRepoFolderProvider repoFolderProvider)
        {
            this.repoFolderProvider = repoFolderProvider;
        }

        public Task<GitRepoCollection> List(GitRepoQuery query)
        {
            var repos = repoFolderProvider.GetDirectoryInfo().GetDirectories($"*{query.Name}*");
            var results = repos.Skip(query.SkipTo(repos.Length)).Take(query.Limit).Select(i => GetGitRepoInfo(i));

            return Task.FromResult(new GitRepoCollection(query, repos.Length, results));
        }

        public Task<GitRepo> Get(String name)
        {
            string fullPath = GetRepoPath(name);
            if (!Directory.Exists(fullPath))
            {
                throw new InvalidOperationException($"A repository named '{fullPath}' could not be found.");
            }

            var dirInfo = new DirectoryInfo(fullPath);
            return Task.FromResult(GetGitRepoInfo(dirInfo));
        }

        public Task<GitRepo> Add(GitRepoInput gitRepo)
        {
            string fullPath = GetRepoPath(gitRepo.Name);
            if (Directory.Exists(fullPath))
            {
                throw new InvalidOperationException($"A repository named '{gitRepo}' already exists.");
            }

            Directory.CreateDirectory(fullPath);

            var dirInfo = new DirectoryInfo(fullPath);
            return Task.FromResult(GetGitRepoInfo(dirInfo));
        }

        public Task Delete(String name)
        {
            string fullPath = GetRepoPath(name);
            Directory.Delete(fullPath, true);
            return Task.CompletedTask;
        }

        public Task<bool> HasGitRepos()
        {
            var dirInfo = repoFolderProvider.GetDirectoryInfo();
            return Task.FromResult(dirInfo.Exists && dirInfo.GetDirectories().Length > 0);
        }

        public virtual async Task AddRange(IEnumerable<GitRepoInput> gitRepos)
        {
            foreach (var repo in gitRepos)
            {
                await Add(repo);
            }
        }

        private string GetRepoPath(string name)
        {
            var baseDir = repoFolderProvider.BaseDir;
            var dir = Path.Combine(baseDir, name);
            if (!dir.StartsWith(baseDir))
            {
                throw new InvalidOperationException($"The path '{dir}' is not within the repo base path '{baseDir}'.");
            }

            return dir;
        }

        private static GitRepo GetGitRepoInfo(DirectoryInfo dirInfo)
        {
            return new GitRepo()
            {
                Name = dirInfo.Name,
                Created = dirInfo.CreationTime,
                Modified = dirInfo.LastWriteTime
            };
        }
    }
}