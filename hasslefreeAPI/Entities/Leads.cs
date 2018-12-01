using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class Leads
    {
        public int LeadId { get; set; }
        public string Description { get; set; }
        public short? Salutation { get; set; }
        public string LeadFirstName { get; set; }
        public string LeadLastName { get; set; }
        public DateTime? LeadDate { get; set; }
        public string Email { get; set; }
        public short? SalesStage { get; set; }
        public int? LeadOwnerExecutiveId { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public short? Country { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddressLine1 { get; set; }
        public string CompanyAddressLine2 { get; set; }
        public string CompanyAddressLine3 { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyPostalCode { get; set; }
        public short? CompanyCountry { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyTurnover { get; set; }
        public short? IndustryId { get; set; }
        public short? IndustrySubTypeId { get; set; }
        public short? LeadSource { get; set; }
        public string DetailDescription { get; set; }
        public int? ContactId { get; set; }
        public int? OpportunityId { get; set; }
        public int? AccountId { get; set; }
        public bool? Converted { get; set; }
        public bool? FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public Accounts Account { get; set; }
    }
}
