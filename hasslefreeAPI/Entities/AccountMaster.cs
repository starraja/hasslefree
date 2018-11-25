using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class AccountMaster
    {
        public int AccountId { get; set; }
        public string Type { get; set; }
        public string AccountName { get; set; }
        public decimal TurnOver { get; set; }
        public string WebSite { get; set; }
        public short? IndustryTypeSubTypeId { get; set; }
        public bool? IsCustomer { get; set; }
        public bool? IsActive { get; set; }
        public int? ReferenceId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string Source { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
    }
}
