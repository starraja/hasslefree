using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Models
{
    public class ProductListDto
    {
        public int ProductListId { get; set; }
        public int ProductId { get; set; }
        public short? Quantity { get; set; }
        public short? Uom { get; set; }
        public decimal? Rate { get; set; }
        public double? Discount { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? Amount { get; set; }
        public int? Source { get; set; }
        public int? ReferenceId { get; set; }
        public bool? FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
