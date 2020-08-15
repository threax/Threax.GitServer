using System.IO;

namespace Threax.GitServer.Services
{
    public interface IRepoFolderProvider
    {
        string BaseDir { get; }

        DirectoryInfo GetDirectoryInfo();
    }
}