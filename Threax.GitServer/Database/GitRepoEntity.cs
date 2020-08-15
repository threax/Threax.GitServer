using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;

namespace Threax.GitServer.Database 
{
    public partial class GitRepoEntity : ICreatedModified
    {
        [Key]
        public Guid GitRepoId { get; set; }

        public String Name { get; set; }

        public String ClonePath { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}