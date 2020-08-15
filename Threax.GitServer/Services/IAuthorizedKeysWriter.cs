using System.Collections.Generic;

namespace Threax.GitServer.Services
{
    public interface IAuthorizedKeysWriter
    {
        void WriteAuthorizedKeys(IEnumerable<string> publicKeys);
    }
}