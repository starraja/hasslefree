using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class Documents
    {
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public int? Source { get; set; }
        public int? ReferenceId { get; set; }
        public bool? FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
