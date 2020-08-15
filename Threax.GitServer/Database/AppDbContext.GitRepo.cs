using Microsoft.EntityFrameworkCore;

namespace Threax.GitServer.Database
{
    public partial class AppDbContext
    {
        public DbSet<GitRepoEntity> GitRepos { get; set; }
    }
}
