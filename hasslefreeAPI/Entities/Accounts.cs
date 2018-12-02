using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class Accounts
    {
        public Accounts()
        {
            Address = new HashSet<Address>();
            Leads = new HashSet<Leads>();
        }

        public int AccountId { get; set; }
        public string Type { get; set; }
        public string AccountName { get; set; }
        public string Website { get; set; }
        public string Turnover { get; set; }
        public short? IndustryId { get; set; }
        public short? IndustrySubTypeId { get; set; }
        public short? LeadSource { get; set; }
        public string WorkPhoneMain { get; set; }
        public string WorkPhoneAlternate { get; set; }
        public string Employees { get; set; }
        public int? ParentId { get; set; }
        public int? CampaignId { get; set; }
        public string DetailDescription { get; set; }
        public bool? FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public Contacts Contacts { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<Leads> Leads { get; set; }
    }
}
