using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
        public RoleMaster Role { get; set; }
        public UserMaster User { get; set; }
    }
}
