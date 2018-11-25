using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class ProductMaster
    {
        public ProductMaster()
        {
            ProductList = new HashSet<ProductList>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Rate { get; set; }
        public short? Uom { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
        public ICollection<ProductList> ProductList { get; set; }
    }
}
