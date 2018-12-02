using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class Activities
    {
        public int ActivityId { get; set; }
        public short ActivityTypeId { get; set; }
        public short ActivitySubTypeId { get; set; }
        public string ActivityTitle { get; set; }
        public DateTime ActivityStartTime { get; set; }
        public DateTime ActivityEndTime { get; set; }
        public string ActivityLocation { get; set; }
        public short StatusId { get; set; }
        public int? ActivityOwner { get; set; }
        public int? Source { get; set; }
        public int? ReferenceId { get; set; }
        public bool? FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
