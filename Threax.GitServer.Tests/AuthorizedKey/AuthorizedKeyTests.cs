using AutoMapper;
using Threax.GitServer.Database;
using Threax.GitServer.InputModels;
using Threax.GitServer.Repository;
using Threax.GitServer.ViewModels;
using Threax.GitServer.Mappers;
using System;
using Threax.AspNetCore.Tests;
using Xunit;
using System.Collections.Generic;

namespace Threax.GitServer.Tests
{
    public static partial class AuthorizedKeyTests
    {
        private static Mockup SetupModel(this Mockup mockup)
        {
            mockup.Add<IAuthorizedKeyRepository>(m => new AuthorizedKeyRepository(m.Get<AppDbContext>(), m.Get<AppMapper>()));

            return mockup;
        }

        public static AuthorizedKeyInput CreateInput(String seed = "", String Name = default(String), String PublicKey = default(String))
        {
            return new AuthorizedKeyInput()
            {
                Name = Name != null ? Name : $"Name {seed}",
                PublicKey = PublicKey != null ? PublicKey : $"PublicKey {seed}",
            };
        }

        public static AuthorizedKeyEntity CreateEntity(String seed = "", Guid? AuthorizedKeyId = default(Guid?), String Name = default(String), String PublicKey = default(String))
        {
            return new AuthorizedKeyEntity()
            {
                AuthorizedKeyId = AuthorizedKeyId.HasValue ? AuthorizedKeyId.Value : Guid.NewGuid(),
                Name = Name != null ? Name : $"Name {seed}",
                PublicKey = PublicKey != null ? PublicKey : $"PublicKey {seed}",
            };
        }

        public static AuthorizedKey CreateView(String seed = "", Guid? AuthorizedKeyId = default(Guid?), String Name = default(String), String PublicKey = default(String))
        {
            return new AuthorizedKey()
            {
                AuthorizedKeyId = AuthorizedKeyId.HasValue ? AuthorizedKeyId.Value : Guid.NewGuid(),
                Name = Name != null ? Name : $"Name {seed}",
                PublicKey = PublicKey != null ? PublicKey : $"PublicKey {seed}",
            };
        }

        public static void AssertEqual(AuthorizedKeyInput expected, AuthorizedKeyEntity actual)
        {
           Assert.Equal(expected.Name, actual.Name);
           Assert.Equal(expected.PublicKey, actual.PublicKey);
        }

        public static void AssertEqual(AuthorizedKeyEntity expected, AuthorizedKey actual)
        {
           Assert.Equal(expected.Name, actual.Name);
           Assert.Equal(expected.PublicKey, actual.PublicKey);
        }

    }
}