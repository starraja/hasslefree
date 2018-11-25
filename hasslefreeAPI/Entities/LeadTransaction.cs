using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class LeadTransaction
    {
        public int LeadId { get; set; }
        public string Description { get; set; }
        public DateTime LeadDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public short? CompanyTypeId { get; set; }
        public short? Accategory { get; set; }
        public short? LeadSource { get; set; }
        public short? SalesStage { get; set; }
        public int LeadOwnerExecutiveId { get; set; }
        public string BuyerRef { get; set; }
        public int AccountId { get; set; }
        public int ContactId { get; set; }
        public short? IndustrySubIndId { get; set; }
        public short? LeadTypeSubTypeId { get; set; }
        public short? Region { get; set; }
        public int ExecutiveId { get; set; }
        public string DetailDescription { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public bool? Status { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
    }
}
