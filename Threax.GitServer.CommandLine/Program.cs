using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Client.OpenIdConnect;
using Threax.ConsoleApp;
using Threax.GitServer.CommandLine.Controller;

namespace Threax.GitServer.CommandLine
{
    class Program
    {
        static Task Main(string[] args)
        {
            int i = -1;
            var command = args.Length > ++i ? args[i] : throw new InvalidOperationException($"Cannot find command in position {i}.");
            var url = args.Length > ++i ? args[i] : throw new InvalidOperationException($"Cannot find service url in position {i}.");
            var credentialsFile = args.Length > ++i ? args[i] : throw new InvalidOperationException($"Cannot find credentials file in position {i}.");

            return AppHost
                .Setup<IController, HelpController>(command, services =>
                {
                    services.AddSingleton<IArgsProvider>(s => new ArgsProvider(args));

                    services.AddLogging(o =>
                    {
                        o.AddConsole();
                    });

                    services.AddHalcyonClient();

                    services.AddThreaxGitServerClient(o =>
                    {
                        o.ServiceUrl = args[1];
                    })
                    .SetupHttpClientFactoryWithClientCredentials(o =>
                    {
                        o.ClientCredentials = JsonConvert.DeserializeObject<ClientCredentailsAccessTokenFactoryOptions>(File.ReadAllText(credentialsFile));
                    });

                    services.AddSingleton<IArgsProvider>(s => new ArgsProvider(args));

                })
                .Run(c => c.Run());
        }
    }
}
