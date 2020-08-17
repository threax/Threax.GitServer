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
        [UiSearch]
        public String Name { get; set; }
    }
}