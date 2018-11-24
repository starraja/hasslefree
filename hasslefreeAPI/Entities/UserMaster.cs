using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class UserMaster
    {
        public UserMaster()
        {
            InverseCreatedByNavigation = new HashSet<UserMaster>();
            InverseModifiedByNavigation = new HashSet<UserMaster>();
            PermissionMasterCreatedByNavigation = new HashSet<PermissionMaster>();
            PermissionMasterModifiedByNavigation = new HashSet<PermissionMaster>();
            RoleMasterCreatedByNavigation = new HashSet<RoleMaster>();
            RoleMasterModifiedByNavigation = new HashSet<RoleMaster>();
            RolePermissionCreatedByNavigation = new HashSet<RolePermission>();
            RolePermissionModifiedByNavigation = new HashSet<RolePermission>();
            UserRoleCreatedByNavigation = new HashSet<UserRole>();
            UserRoleModifiedByNavigation = new HashSet<UserRole>();
            UserRoleUser = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime? LastAccessedDateTime { get; set; }
        public string LastAccessedIp { get; set; }
        public string PasswordToken { get; set; }
        public bool Active { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
        public ICollection<UserMaster> InverseCreatedByNavigation { get; set; }
        public ICollection<UserMaster> InverseModifiedByNavigation { get; set; }
        public ICollection<PermissionMaster> PermissionMasterCreatedByNavigation { get; set; }
        public ICollection<PermissionMaster> PermissionMasterModifiedByNavigation { get; set; }
        public ICollection<RoleMaster> RoleMasterCreatedByNavigation { get; set; }
        public ICollection<RoleMaster> RoleMasterModifiedByNavigation { get; set; }
        public ICollection<RolePermission> RolePermissionCreatedByNavigation { get; set; }
        public ICollection<RolePermission> RolePermissionModifiedByNavigation { get; set; }
        public ICollection<UserRole> UserRoleCreatedByNavigation { get; set; }
        public ICollection<UserRole> UserRoleModifiedByNavigation { get; set; }
        public ICollection<UserRole> UserRoleUser { get; set; }
    }
}
