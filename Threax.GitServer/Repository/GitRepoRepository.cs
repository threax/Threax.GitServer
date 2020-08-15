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
using System.Diagnostics;

namespace Threax.GitServer.Repository
{
    public partial class GitRepoRepository : IGitRepoRepository
    {
        private readonly IRepoFolderProvider repoFolderProvider;
        private readonly IClonePathBuilder clonePathBuilder;
        private readonly IProcessRunner processRunner;

        public GitRepoRepository(IRepoFolderProvider repoFolderProvider, IClonePathBuilder clonePathBuilder, IProcessRunner processRunner)
        {
            this.repoFolderProvider = repoFolderProvider;
            this.clonePathBuilder = clonePathBuilder;
            this.processRunner = processRunner;
        }

        public Task<GitRepoCollection> List(GitRepoQuery query)
        {
            var repos = repoFolderProvider.GetDirectoryInfo().EnumerateDirectories($"*{query.Name}*").OrderByDescending(i => i.LastAccessTime).ToList();
            var results = repos.Skip(query.SkipTo(repos.Count)).Take(query.Limit).Select(i => GetGitRepoInfo(i));

            return Task.FromResult(new GitRepoCollection(query, repos.Count, results));
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
                throw new InvalidOperationException($"A repository named '{gitRepo.Name}' already exists.");
            }

            Directory.CreateDirectory(fullPath);
            var startInfo = new ProcessStartInfo("git", "init --bare");
            startInfo.WorkingDirectory = fullPath;
            var result = processRunner.RunProcessWithOutput(startInfo);
            if(result != 0)
            {
                throw new InvalidOperationException($"Error initializing git repository '{gitRepo.Name}'.");
            }

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

        private GitRepo GetGitRepoInfo(DirectoryInfo dirInfo)
        {
            return new GitRepo()
            {
                Name = dirInfo.Name,
                Created = dirInfo.CreationTime,
                Modified = dirInfo.LastWriteTime,
                ClonePath = this.clonePathBuilder.GetCloneUrl(dirInfo.Name)
            };
        }
    }
}