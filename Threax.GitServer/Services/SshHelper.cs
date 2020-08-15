using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Threax.GitServer.Services;

namespace Threax.GitServer.Services
{
    // Leaving this for reference since it works, but it is not acutally used.
    public class SshHelper
    {
        private readonly string host;
        private readonly string port;
        private readonly IRepoFolderProvider repoFolderProvider;
        private readonly IProcessRunner processRunner;

        public SshHelper(String host, String port, IRepoFolderProvider repoFolderProvider, IProcessRunner processRunner)
        {
            this.host = host;
            this.port = port;
            this.repoFolderProvider = repoFolderProvider;
            this.processRunner = processRunner;
        }

        public async Task<bool> RepoExists(String name)
        {
            var path = UnixifyPath(Path.Combine(repoFolderProvider.BaseDir, name));
            var result = (await RunSshCommand($"if [ -d \"{path}\" ]; then exit 5; else exit 6; fi;"));
            if(result == 5)
            {
                return true;
            }
            if(result == 6)
            {
                return false;
            }
            throw new InvalidOperationException($"Error running ssh command. Exit code was {result}");
        }

        public async Task CreateRepo(String name)
        {
            var path = UnixifyPath(Path.Combine(repoFolderProvider.BaseDir, name));

            if (await RepoExists(name))
            {
                throw new InvalidOperationException($"Repository {name} already exists.");
            }

            var result = (await RunSshCommand($"mkdir -p \"{path}\"; cd \"{path}\"; git init --bare"));
            if(result != 0)
            {
                throw new InvalidOperationException($"Error running create repo command. Exit Code: {result}");
            }
        }

        public async Task DeleteRepo(String name)
        {
            var path = UnixifyPath(Path.Combine(repoFolderProvider.BaseDir, name));
            var result = (await RunSshCommand($"rm -r \"{path}\""));
            if (result != 0)
            {
                throw new InvalidOperationException($"Error running create repo command. Exit Code: {result}");
            }
        }

        public Task<int> RunSshCommand(String command)
        {
            var startInfo = new ProcessStartInfo("ssh", $"-t \"{host}\" -p {port} \"{command}\"");
            return Task.FromResult(processRunner.RunProcessWithOutput(startInfo));
        }

        private String UnixifyPath(String path)
        {
            return path.Replace('\\', '/');
        }
    }
}
