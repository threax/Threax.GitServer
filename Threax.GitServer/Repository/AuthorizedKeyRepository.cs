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
    public partial class AuthorizedKeyRepository : IAuthorizedKeyRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public AuthorizedKeyRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<AuthorizedKeyCollection> List(AuthorizedKeyQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await mapper.ProjectAuthorizedKey(dbQuery).ToListAsync();

            return new AuthorizedKeyCollection(query, total, results);
        }

        public async Task<AuthorizedKey> Get(Guid authorizedKeyId)
        {
            var entity = await this.Entity(authorizedKeyId);
            return mapper.MapAuthorizedKey(entity, new AuthorizedKey());
        }

        public async Task<AuthorizedKey> Add(AuthorizedKeyInput authorizedKey)
        {
            var entity = mapper.MapAuthorizedKey(authorizedKey, new AuthorizedKeyEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapAuthorizedKey(entity, new AuthorizedKey());
        }

        public async Task<AuthorizedKey> Update(Guid authorizedKeyId, AuthorizedKeyInput authorizedKey)
        {
            var entity = await this.Entity(authorizedKeyId);
            if (entity != null)
            {
                mapper.MapAuthorizedKey(authorizedKey, entity);
                await SaveChanges();
                return mapper.MapAuthorizedKey(entity, new AuthorizedKey());
            }
            throw new KeyNotFoundException($"Cannot find authorizedKey {authorizedKeyId.ToString()}");
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

        public virtual async Task<bool> HasAuthorizedKeys()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<AuthorizedKeyInput> authorizedKeys)
        {
            var entities = authorizedKeys.Select(i => mapper.MapAuthorizedKey(i, new AuthorizedKeyEntity()));
            this.dbContext.AuthorizedKeys.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<AuthorizedKeyEntity> Entities
        {
            get
            {
                return dbContext.AuthorizedKeys;
            }
        }

        private Task<AuthorizedKeyEntity> Entity(Guid authorizedKeyId)
        {
            return Entities.Where(i => i.AuthorizedKeyId == authorizedKeyId).FirstOrDefaultAsync();
        }
    }
}