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
    public partial class AuthorizedKeyQuery : PagedCollectionQuery
    {
        /// <summary>
        /// Lookup a authorizedKey by id.
        /// </summary>
        public Guid? AuthorizedKeyId { get; set; }

        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<AuthorizedKeyEntity>> Create(IQueryable<AuthorizedKeyEntity> query)
        {
            if (AuthorizedKeyId != null)
            {
                query = query.Where(i => i.AuthorizedKeyId == AuthorizedKeyId);
            }
            else
            {
                //Customize query further
            }

            return Task.FromResult(query);
        }
    }
}