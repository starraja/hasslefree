using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class RoleMaster
    {
        public RoleMaster()
        {
            RolePermission = new HashSet<RolePermission>();
            UserRole = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
