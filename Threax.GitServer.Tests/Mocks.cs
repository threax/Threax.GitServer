using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Threax.GitServer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Threax.AspNetCore.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace Threax.GitServer.Tests
{
    public static class Mocks
    {
        /// <summary>
        /// Setup global shared mockups that can be used across may tests.
        /// </summary>
        /// <param name="mockup">The mockup class to configure.</param>
        /// <returns>The passed in mockup test.</returns>
        public static Mockup SetupGlobal(this Mockup mockup)
        {
            mockup.MockServiceCollection.AddTimeTracking();
            mockup.MockServiceCollection.AddAppMapper(includeAutomapperConfig: true);

            mockup.Add<AppDbContext>(m => new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                                                                        .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                                                        .Options));

            mockup.Add<IIdentity>(m => CreateIdentity(Roles.DatabaseRoles()));

            mockup.Add<ClaimsPrincipal>(m => new ClaimsPrincipal(m.Get<IIdentity>()));

            mockup.Add<HttpContext>(m => new DefaultHttpContext()
            {
                User = m.Get<ClaimsPrincipal>()
            });

            mockup.Add<IHttpContextAccessor>(m => new HttpContextAccessor()
            {
                HttpContext = m.Get<HttpContext>()
            });

            mockup.Add<ControllerContext>(m => new ControllerContext()
            {
                HttpContext = m.Get<HttpContext>()
            });

            return mockup;
        }

        /// <summary>
        /// Setup a IWebHost in the mocks. This will use the configuration files from the test project.
        /// </summary>
        /// <param name="mockup">The mockup class to configure.</param>
        /// <returns>The passed in mockup test.</returns>
        public static Mockup SetupWebHost(this Mockup mockup)
        {
            mockup.Add<IWebHost>(m =>
            {
                var hostBuilder = new WebHostBuilder()
                                    .UseEnvironment("development")
                                    .UseKestrel()
                                    .UseStartup<Startup>()
                                    .ConfigureAppConfiguration(configuration =>
                                    {
                                        configuration.Sources.Clear();
                                        configuration.AddJsonFile("appsettings.json");
                                        configuration.AddJsonFile("appsettings.Development.json");
                                    });

                return hostBuilder.Build();
            });

            return mockup;
        }

        /// <summary>
        /// Helper to create an identity. Can pass in roles to assign, will automatically setup the user
        /// guid and any other common properties.
        /// </summary>
        /// <param name="claims">The claims to add.</param>
        /// <returns>The identity.</returns>
        public static IIdentity CreateIdentity(IEnumerable<String> roles)
        {
            return new ClaimsIdentity(roles.Select(i => new Claim(ClaimTypes.Role, i)).Concat(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            }));
        }
    }
}
