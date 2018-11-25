using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class ActivityList
    {
        public int ActivityId { get; set; }
        public short TypeSubtypeId { get; set; }
        public DateTime ActivityStartTime { get; set; }
        public DateTime ActivityEndTime { get; set; }
        public short StatusId { get; set; }
        public string Km { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public int? ReferenceId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
    }
}
