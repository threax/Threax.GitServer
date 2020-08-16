using Threax.GitServer.Client;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Threax.AspNetCore.Halcyon.Client;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        /// <summary>
        /// Add the Threax.GitServer setup to use client credentials to connect to the service.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configure">The configure callback.</param>
        /// <returns></returns>
        public static IHalcyonClientSetup<EntryPointInjector> AddThreaxGitServerClient(this IServiceCollection services, Action<GitServerClientOptions> configure)
        {
            var options = new GitServerClientOptions();
            configure?.Invoke(options);

            services.TryAddSingleton<IHttpClientFactory<EntryPointInjector>, DefaultHttpClientFactory<EntryPointInjector>>();
            services.TryAddScoped<EntryPointInjector>(s =>
            {
                return new EntryPointInjector(options.ServiceUrl, s.GetRequiredService<IHttpClientFactory<EntryPointInjector>>());
            });

            return new HalcyonClientSetup<EntryPointInjector>(services);
        }
    }
}
