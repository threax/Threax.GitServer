using System.Diagnostics;

namespace Threax.GitServer.Services
{
    public interface IProcessRunner
    {
        int RunProcessWithOutput(ProcessStartInfo startInfo);
        string RunProcessWithOutputGetOutput(ProcessStartInfo startInfo);
        string RunProcessWithOutputGetOutput(ProcessStartInfo startInfo, out int exitCode);
    }
}