using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class RolePermission
    {
        public int RolePermissionId { get; set; }
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
        public PermissionMaster Permission { get; set; }
        public RoleMaster Role { get; set; }
    }
}
