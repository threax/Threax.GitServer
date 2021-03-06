using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Threax.ReflectedServices;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Threax.GitServer.Repository;

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