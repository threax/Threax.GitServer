using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;

namespace Threax.GitServer.ModelSchemas
{
    [RequireAuthorization(typeof(Roles), nameof(Roles.EditAuthorizedKeys))]
    public abstract class AuthorizedKey
    {
        [Required]
        [MaxLength(450)]
        public String Name { get; set; }

        [Required]
        [MaxLength(10000)]
        public String PublicKey { get; set; }
    }
}
