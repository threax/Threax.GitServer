using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Threax.GitServer.Tests
{
    public class MapperConfigurationTests : IDisposable
    {
        private Mockup mockup = new Mockup().SetupGlobal();

        public void Dispose()
        {
            mockup.Dispose();
        }

        [Fact]
        public void Valid()
        {
            mockup.Get<MapperConfiguration>().AssertConfigurationIsValid();
        }
    }
}
