using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;

namespace Threax.GitServer.ModelSchemas
{
    [KeyName("Name")]
    [KeyType(typeof(String))]
    [RequireAuthorization(typeof(Roles), nameof(Roles.EditValues))]
    public class GitRepo
    {
        public String ClonePath { get; set; }
    }
}
