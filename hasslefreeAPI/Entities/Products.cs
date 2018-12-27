using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public short ProductType { get; set; }
        public string Name { get; set; }
        public decimal? Rate { get; set; }
        public bool? FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
