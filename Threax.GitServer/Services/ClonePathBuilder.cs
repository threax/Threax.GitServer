using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.GitServer.Services
{
    public class ClonePathBuilder : IClonePathBuilder
    {
        private readonly string urlFormat;

        public ClonePathBuilder(String urlFormat)
        {
            this.urlFormat = urlFormat;
        }

        public String GetCloneUrl(String repoName)
        {
            return String.Format(this.urlFormat, repoName);
        }
    }
}
