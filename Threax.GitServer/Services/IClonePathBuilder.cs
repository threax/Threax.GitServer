namespace Threax.GitServer.Services
{
    public interface IClonePathBuilder
    {
        string GetCloneUrl(string repoName);
    }
}