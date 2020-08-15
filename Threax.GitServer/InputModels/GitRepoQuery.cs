using Halcyon.HAL.Attributes;
using Threax.GitServer.Controllers;
using Threax.GitServer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.AspNetCore.Models;
using System.ComponentModel.DataAnnotations;

namespace Threax.GitServer.InputModels
{
    [HalModel]
    public partial class GitRepoQuery : PagedCollectionQuery
    {
        /// <summary>
        /// Lookup a gitRepo by id.
        /// </summary>
        public Guid? GitRepoId { get; set; }

        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<GitRepoEntity>> Create(IQueryable<GitRepoEntity> query)
        {
            if (GitRepoId != null)
            {
                query = query.Where(i => i.GitRepoId == GitRepoId);
            }
            else
            {
                //Customize query further
            }

            return Task.FromResult(query);
        }
    }
}