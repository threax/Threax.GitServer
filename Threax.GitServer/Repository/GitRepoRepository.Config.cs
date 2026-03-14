using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Threax.ReflectedServices;

namespace Threax.GitServer.Repository.Config
{
    public partial class GitRepoRepositoryConfig : IServiceSetup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            OnConfigureServices(services);

            services.TryAddScoped<IGitRepoRepository, GitRepoRepository>();
        }

        partial void OnConfigureServices(IServiceCollection services);
    }
}