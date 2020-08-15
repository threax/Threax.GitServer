using AutoMapper;
using Threax.GitServer.Database;
using Threax.GitServer.ViewModels;
using Threax.GitServer.Mappers;
using System;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Threax.GitServer.Tests
{
    public static partial class AuthorizedKeyTests
    {
        public class Profile : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Profile()
            {

            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            void InputToEntity()
            {
                var mapper = mockup.Get<AppMapper>();
                var input = AuthorizedKeyTests.CreateInput();
                var entity = mapper.MapAuthorizedKey(input, new AuthorizedKeyEntity());

                //Make sure the id does not copy over
                Assert.Equal(default(Guid), entity.AuthorizedKeyId);
                AssertEqual(input, entity);
            }

            [Fact]
            void EntityToView()
            {
                var mapper = mockup.Get<AppMapper>();
                var entity = AuthorizedKeyTests.CreateEntity();
                var view = mapper.MapAuthorizedKey(entity, new AuthorizedKey());

                Assert.Equal(entity.AuthorizedKeyId, view.AuthorizedKeyId);
                AssertEqual(entity, view);
            }
        }
    }
}