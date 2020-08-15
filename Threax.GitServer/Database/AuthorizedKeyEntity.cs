using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;

namespace Threax.GitServer.Database 
{
    public partial class AuthorizedKeyEntity : ICreatedModified
    {
        [Key]
        public Guid AuthorizedKeyId { get; set; }

        [Required(ErrorMessage = "Name must have a value.")]
        [MaxLength(450, ErrorMessage = "Name must be less than 450 characters.")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Public Key must have a value.")]
        [MaxLength(10000, ErrorMessage = "Public Key must be less than 10000 characters.")]
        public String PublicKey { get; set; }

        public bool Enabled { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
