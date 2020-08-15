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

namespace Threax.GitServer.Repository
{
    public partial class GitRepoRepository : IGitRepoRepository
    {
        private readonly AppDbContext dbContext;
        private readonly AppMapper mapper;
        private readonly DirectoryInfo repoDir;

        public GitRepoRepository(AppDbContext dbContext, AppMapper mapper, AppConfig appConfig)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.repoDir = new DirectoryInfo(Path.GetFullPath(appConfig.RepoBaseDir));
            if (!repoDir.Exists)
            {
                throw new DirectoryNotFoundException($"Cannot find repository directory '{repoDir}'.");
            }
        }

        public Task<GitRepoCollection> List(GitRepoQuery query)
        {
            //var dbQuery = await query.Create(this.Entities);

            //var total = await dbQuery.CountAsync();
            //dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            //var results = await mapper.ProjectGitRepo(dbQuery).ToListAsync();
            var repos = repoDir.GetDirectories($"*{query.Name}*");
            var results = repos.Skip(query.SkipTo(repos.Length)).Take(query.Limit).Select(i => GetGitRepoInfo(i));

            return Task.FromResult(new GitRepoCollection(query, repos.Length, results));
        }

        public Task<GitRepo> Get(String name)
        {
            string fullPath = GetFullPath(name);
            if (!Directory.Exists(fullPath))
            {
                throw new InvalidOperationException($"A repository named '{fullPath}' could not be found.");
            }

            var dirInfo = new DirectoryInfo(fullPath);
            return Task.FromResult(GetGitRepoInfo(dirInfo));
        }

        public Task<GitRepo> Add(GitRepoInput gitRepo)
        {
            string fullPath = GetFullPath(gitRepo.Name);
            if (Directory.Exists(fullPath))
            {
                throw new InvalidOperationException($"A repository named '{fullPath}' already exists.");
            }

            Directory.CreateDirectory(fullPath);

            var dirInfo = new DirectoryInfo(fullPath);
            return Task.FromResult(GetGitRepoInfo(dirInfo));
        }

        public Task Delete(String name)
        {
            string fullPath = GetFullPath(name);
            Directory.Delete(fullPath, true);
            return Task.CompletedTask;
        }

        public Task<bool> HasGitRepos()
        {
            return Task.FromResult(repoDir.GetDirectories().Length > 0);
        }

        public virtual async Task AddRange(IEnumerable<GitRepoInput> gitRepos)
        {
            foreach (var repo in gitRepos)
            {
                await Add(repo);
            }
        }

        private string GetFullPath(string name)
        {
            return Path.Combine(repoDir.FullName, name);
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