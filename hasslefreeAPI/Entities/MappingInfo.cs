using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class MappingInfo
    {
        public int MappingId { get; set; }
        public string ParentType { get; set; }
        public int ParentTypeId { get; set; }
        public string ChildType { get; set; }
        public int ChildTypeId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
    }
}
