using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Threax.GitServer.InputModels 
{
    [HalModel]
    public partial class GitRepoInput
    {
        public String Name { get; set; }

        public String ClonePath { get; set; }

    }
}
