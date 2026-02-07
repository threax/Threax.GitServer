using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Threax.AspNetCore.Halcyon.ClientGen;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Threax.GitServer.Tests
{
    public class ClientGen : IDisposable
    {
        private Mockup mockup = new Mockup().SetupWebHost();

        public void Dispose()
        {
            mockup.Dispose();
        }

        [Fact]
        public void Run()
        {
            var host = mockup.Get<IHost>();
            var clientWriter = host.Services.GetRequiredService<IClientGenerator>();
            var clientTest = new ClientGenTester(clientWriter);
            clientTest.Verify();
        }
    }
}
