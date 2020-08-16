using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threax.GitServer.CommandLine
{
    interface IController
    {
        Task Run();
    }
}
