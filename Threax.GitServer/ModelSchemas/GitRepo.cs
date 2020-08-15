using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.GitServer.ModelSchemas
{
    public class GitRepo
    {
        public String Name { get; set; }

        public String ClonePath { get; set; }
    }
}
