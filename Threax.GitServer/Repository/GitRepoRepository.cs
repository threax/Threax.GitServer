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

namespace Threax.GitServer.Repository
{
    public partial class GitRepoRepository : IGitRepoRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public GitRepoRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<GitRepoCollection> List(GitRepoQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await mapper.ProjectGitRepo(dbQuery).ToListAsync();

            return new GitRepoCollection(query, total, results);
        }

        public async Task<GitRepo> Get(Guid gitRepoId)
        {
            var entity = await this.Entity(gitRepoId);
            return mapper.MapGitRepo(entity, new GitRepo());
        }

        public async Task<GitRepo> Add(GitRepoInput gitRepo)
        {
            var entity = mapper.MapGitRepo(gitRepo, new GitRepoEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapGitRepo(entity, new GitRepo());
        }

        public async Task<GitRepo> Update(Guid gitRepoId, GitRepoInput gitRepo)
        {
            var entity = await this.Entity(gitRepoId);
            if (entity != null)
            {
                mapper.MapGitRepo(gitRepo, entity);
                await SaveChanges();
                return mapper.MapGitRepo(entity, new GitRepo());
            }
            throw new KeyNotFoundException($"Cannot find gitRepo {gitRepoId.ToString()}");
        }

        public async Task Delete(Guid id)
        {
            var entity = await this.Entity(id);
            if (entity != null)
            {
                Entities.Remove(entity);
                await SaveChanges();
            }
        }

        public virtual async Task<bool> HasGitRepos()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<GitRepoInput> gitRepos)
        {
            var entities = gitRepos.Select(i => mapper.MapGitRepo(i, new GitRepoEntity()));
            this.dbContext.GitRepos.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<GitRepoEntity> Entities
        {
            get
            {
                return dbContext.GitRepos;
            }
        }

        private Task<GitRepoEntity> Entity(Guid gitRepoId)
        {
            return Entities.Where(i => i.GitRepoId == gitRepoId).FirstOrDefaultAsync();
        }
    }
}