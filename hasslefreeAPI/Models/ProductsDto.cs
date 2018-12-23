using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Models
{
    public class ProductsDto
    {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public decimal? Rate { get; set; }
            public bool? FlagActive { get; set; }
            public int CreatedBy { get; set; }
            public DateTime CreatedDateTime { get; set; }
            public int ModifiedBy { get; set; }
            public DateTime ModifiedDateTime { get; set; }
    }
}
