using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Threax.ConsoleApp;
using Threax.GitServer.Client;

namespace Threax.GitServer.CommandLine.Controller
{
    class AddRepoController : IController
    {
        private readonly EntryPointInjector entryPointInjector;
        private readonly IArgsProvider argsProvider;
        private readonly ILogger<AddRepoController> logger;

        public AddRepoController(EntryPointInjector entryPointInjector, IArgsProvider argsProvider, ILogger<AddRepoController> logger)
        {
            this.entryPointInjector = entryPointInjector;
            this.argsProvider = argsProvider;
            this.logger = logger;
        }

        public async Task Run()
        {
            var entryPoint = await entryPointInjector.Load();
            if (!entryPoint.CanAddGitRepo)
            {
                throw new InvalidOperationException("No permission to add a git repo.");
            }

            var args = argsProvider.Args;
            int i = 2;
            var repoName = args.Length > ++i ? args[i] : throw new InvalidOperationException($"Cannot find repo name in position {i}.");

            await entryPoint.AddGitRepo(new GitRepoInput()
            {
                Name = repoName
            });

            logger.LogInformation($"Added new git repo {repoName} to {entryPoint.LinkForRefresh.Href}");
        }
    }
}
