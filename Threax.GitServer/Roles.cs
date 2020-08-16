using Halcyon.HAL.Attributes;
using Threax.GitServer.Controllers.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.UserBuilder.Entities.Mvc;

namespace Threax.GitServer
{
    /// <summary>
    /// This class makes it easy to keep track of role constants throught the system.
    /// </summary>
    public static class Roles
    {
        public const String EditGitRepos = nameof(EditGitRepos);

        public const String DeleteGitRepos = nameof(DeleteGitRepos);

        public const String EditAuthorizedKeys = nameof(EditAuthorizedKeys);

        /// <summary>
        /// All roles, any roles added above that you want to add to the database should be defined here.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<String> DatabaseRoles()
        {
            yield return EditGitRepos;
            yield return EditAuthorizedKeys;
            yield return DeleteGitRepos;
        }
    }

    [HalModel]
    [HalSelfActionLink(RolesControllerRels.GetUser, typeof(RolesController))]
    [HalActionLink(RolesControllerRels.SetUser, typeof(RolesController))]
    [HalActionLink(CrudRels.Update, RolesControllerRels.SetUser, typeof(RolesController))]
    [HalActionLink(CrudRels.Delete, RolesControllerRels.DeleteUser, typeof(RolesController))]
    public class RoleAssignments : ReflectedRoleAssignments
    {
        public bool EditGitRepos { get; set; }

        public bool DeleteGitRepos { get; set; }

        public bool EditAuthorizedKeys { get; set; }
    }
}
