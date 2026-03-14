using System;
using System.Linq;
using Threax.GitServer.Database;
using Threax.GitServer.InputModels;
using Threax.GitServer.ViewModels;

namespace Threax.GitServer.Mappers
{
    public partial class AppMapper
    {
        public AuthorizedKeyEntity MapAuthorizedKey(AuthorizedKeyInput src, AuthorizedKeyEntity dest)
        {
            //dest.AuthorizedKeyId Ignored
            dest.Name = src.Name;
            dest.PublicKey = src.PublicKey;
            dest.Enabled = src.Enabled;
            dest.Created = GetCreated(dest.Created);
            dest.Modified = DateTime.UtcNow;

            return dest;
        }

        public AuthorizedKey MapAuthorizedKey(AuthorizedKeyEntity src, AuthorizedKey dest)
        {
            dest.AuthorizedKeyId = src.AuthorizedKeyId;
            dest.Name = src.Name;
            dest.PublicKey = src.PublicKey;
            dest.Enabled = src.Enabled;
            dest.Created = src.Created;
            dest.Modified = src.Modified;

            return dest;
        }

        public IQueryable<AuthorizedKey> ProjectAuthorizedKey(IQueryable<AuthorizedKeyEntity> query)
        {
            return query.Select(i => new AuthorizedKey()
            {
                AuthorizedKeyId = i.AuthorizedKeyId,
                Name = i.Name,
                PublicKey = i.PublicKey,
                Enabled = i.Enabled,
                Created = i.Created,
                Modified = i.Modified
            });
        }
    }
}