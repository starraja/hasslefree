using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class ReferenceLookup
    {
        public short ReferenceLookupId { get; set; }
        public string Type { get; set; }
        public short? OrderId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public bool? FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
