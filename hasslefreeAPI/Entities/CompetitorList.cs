using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class CompetitorList
    {
        public int CompetitorId { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public string Remarks { get; set; }
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
