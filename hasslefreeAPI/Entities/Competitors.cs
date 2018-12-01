using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class Competitors
    {
        public int CompetitorId { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public string Remarks { get; set; }
        public int? Source { get; set; }
        public int? RefernceId { get; set; }
        public bool? FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
