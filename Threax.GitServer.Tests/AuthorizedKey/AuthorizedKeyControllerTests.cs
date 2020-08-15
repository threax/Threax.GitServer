using Threax.GitServer.Controllers.Api;
using Threax.GitServer.InputModels;
using Threax.GitServer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Threax.AspNetCore.Tests;
using Xunit;
using Threax.GitServer.Services;

namespace Threax.GitServer.Tests
{
    public static partial class AuthorizedKeyTests
    {
        public class Controller : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Controller()
            {
                mockup.Add<AuthorizedKeysController>(m => new AuthorizedKeysController(m.Get<IAuthorizedKeyRepository>(), m.Get<IAuthorizedKeysWriter>())
                {
                    ControllerContext = m.Get<ControllerContext>()
                });
            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            async Task List()
            {
                var totalItems = 3;

                var controller = mockup.Get<AuthorizedKeysController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(AuthorizedKeyTests.CreateInput()));
                }

                var query = new AuthorizedKeyQuery();
                var result = await controller.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }

            [Fact]
            async Task Get()
            {
                var totalItems = 3;

                var controller = mockup.Get<AuthorizedKeysController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(AuthorizedKeyTests.CreateInput()));
                }

                //Manually add the item we will look back up
                var lookup = await controller.Add(AuthorizedKeyTests.CreateInput());
                var result = await controller.Get(lookup.AuthorizedKeyId);
                Assert.NotNull(result);
            }

            [Fact]
            async Task Add()
            {
                var controller = mockup.Get<AuthorizedKeysController>();

                var result = await controller.Add(AuthorizedKeyTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task Update()
            {
                var controller = mockup.Get<AuthorizedKeysController>();

                var result = await controller.Add(AuthorizedKeyTests.CreateInput());
                Assert.NotNull(result);

                var updateResult = await controller.Update(result.AuthorizedKeyId, AuthorizedKeyTests.CreateInput());
                Assert.NotNull(updateResult);
            }

            [Fact]
            async Task Delete()
            {
                var controller = mockup.Get<AuthorizedKeysController>();

                var result = await controller.Add(AuthorizedKeyTests.CreateInput());
                Assert.NotNull(result);

                var listResult = await controller.List(new AuthorizedKeyQuery());
                Assert.Equal(1, listResult.Total);

                await controller.Delete(result.AuthorizedKeyId);

                listResult = await controller.List(new AuthorizedKeyQuery());
                Assert.Equal(0, listResult.Total);
            }
        }
    }
}