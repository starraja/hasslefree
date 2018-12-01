using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int? Type { get; set; }
        public int AccountId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
        public string Landmark { get; set; }
        public string Remarks { get; set; }
        public bool? FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public Accounts Account { get; set; }
    }
}
