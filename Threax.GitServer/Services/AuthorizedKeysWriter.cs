using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.GitServer.Services
{
    public class AuthorizedKeysWriter : IAuthorizedKeysWriter
    {
        private readonly string authorizedKeysPath;

        public AuthorizedKeysWriter(String authorizedKeysPath)
        {
            this.authorizedKeysPath = Path.GetFullPath(authorizedKeysPath);
        }

        public void WriteAuthorizedKeys(IEnumerable<String> publicKeys)
        {
            using (var writer = new StreamWriter(File.Open(authorizedKeysPath, FileMode.Create, FileAccess.ReadWrite, FileShare.None)))
            {
                foreach (var key in publicKeys)
                {
                    writer.Write(key);
                    writer.Write('\n'); //Destination is always unix
                }
            }
        }
    }
}
