using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.GitServer.Services
{
    public class RepoFolderProvider : IRepoFolderProvider
    {
        private String baseDir;

        public RepoFolderProvider(String baseDir)
        {
            this.baseDir = Path.GetFullPath(baseDir);

            if (!Directory.Exists(this.baseDir))
            {
                Directory.CreateDirectory(this.baseDir);
            }
        }

        public String BaseDir => baseDir;

        public DirectoryInfo GetDirectoryInfo()
        {
            return new DirectoryInfo(baseDir);
        }
    }
}
