using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class PermissionMaster
    {
        public PermissionMaster()
        {
            RolePermission = new HashSet<RolePermission>();
        }

        public int PermissionId { get; set; }
        public string UielementCode { get; set; }
        public string UielementDescription { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; }
    }
}
