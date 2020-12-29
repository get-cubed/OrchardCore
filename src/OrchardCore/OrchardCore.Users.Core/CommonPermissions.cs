using System;
using OrchardCore.Security.Permissions;

namespace OrchardCore.Users
{
    public class CommonPermissions
    {
        /// <summary>
        /// When authorizing request ManageUsers and pass an <see cref="IUser"/>
        /// Do not request a dynamic permission.
        /// </summary>
        public static readonly Permission ManageUsers = new Permission("ManageUsers", "Manage Users of any Role", true);

        // This is a special permission which applies when a user is not assigned to any roles, and they are automatically placed in this role, but it is not recorded in the database.
        public static readonly Permission ManageUsersInAuthenticatedRole = new Permission("ManageUsersInRole_Authenticated", "Manage Users in Role - Authenticated", new[] { ManageUsers });

        // Dynamic permission template.
        private static readonly Permission ManageUsersInRole = new Permission("ManageUsersInRole_{0}", "Manage Users in Role - {0}", new[] { ManageUsers });

        public static Permission CreatePermissionForManageUsersInRole(string name)
            => new Permission(
                    String.Format(ManageUsersInRole.Name, name),
                    String.Format(ManageUsersInRole.Description, name),
                    ManageUsersInRole.ImpliedBy
                );

    }
}
