using Threax.GitServer.Database;
using Threax.GitServer.InputModels;
using Threax.GitServer.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Threax.GitServer.Tests
{
    public static partial class AuthorizedKeyTests
    {
        public class Repository : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Repository()
            {

            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            async Task Add()
            {
                var repo = mockup.Get<IAuthorizedKeyRepository>();
                var result = await repo.Add(AuthorizedKeyTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task AddRange()
            {
                var repo = mockup.Get<IAuthorizedKeyRepository>();
                await repo.AddRange(new AuthorizedKeyInput[] { AuthorizedKeyTests.CreateInput(), AuthorizedKeyTests.CreateInput(), AuthorizedKeyTests.CreateInput() });
            }

            [Fact]
            async Task Delete()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<IAuthorizedKeyRepository>();
                await repo.AddRange(new AuthorizedKeyInput[] { AuthorizedKeyTests.CreateInput(), AuthorizedKeyTests.CreateInput(), AuthorizedKeyTests.CreateInput() });
                var result = await repo.Add(AuthorizedKeyTests.CreateInput());
                Assert.Equal<int>(4, dbContext.AuthorizedKeys.Count());
                await repo.Delete(result.AuthorizedKeyId);
                Assert.Equal<int>(3, dbContext.AuthorizedKeys.Count());
            }

            [Fact]
            async Task Get()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<IAuthorizedKeyRepository>();
                await repo.AddRange(new AuthorizedKeyInput[] { AuthorizedKeyTests.CreateInput(), AuthorizedKeyTests.CreateInput(), AuthorizedKeyTests.CreateInput() });
                var result = await repo.Add(AuthorizedKeyTests.CreateInput());
                Assert.Equal<int>(4, dbContext.AuthorizedKeys.Count());
                var getResult = await repo.Get(result.AuthorizedKeyId);
                Assert.NotNull(getResult);
            }

            [Fact]
            async Task HasAuthorizedKeysEmpty()
            {
                var repo = mockup.Get<IAuthorizedKeyRepository>();
                Assert.False(await repo.HasAuthorizedKeys());
            }

            [Fact]
            async Task HasAuthorizedKeys()
            {
                var repo = mockup.Get<IAuthorizedKeyRepository>();
                await repo.AddRange(new AuthorizedKeyInput[] { AuthorizedKeyTests.CreateInput(), AuthorizedKeyTests.CreateInput(), AuthorizedKeyTests.CreateInput() });
                Assert.True(await repo.HasAuthorizedKeys());
            }

            [Fact]
            async Task List()
            {
                //This could be more complete
                var repo = mockup.Get<IAuthorizedKeyRepository>();
                await repo.AddRange(new AuthorizedKeyInput[] { AuthorizedKeyTests.CreateInput(), AuthorizedKeyTests.CreateInput(), AuthorizedKeyTests.CreateInput() });
                var query = new AuthorizedKeyQuery();
                var result = await repo.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }

            [Fact]
            async Task Update()
            {
                var repo = mockup.Get<IAuthorizedKeyRepository>();
                var result = await repo.Add(AuthorizedKeyTests.CreateInput());
                Assert.NotNull(result);
                var updateResult = await repo.Update(result.AuthorizedKeyId, AuthorizedKeyTests.CreateInput());
                Assert.NotNull(updateResult);
            }
        }
    }
}