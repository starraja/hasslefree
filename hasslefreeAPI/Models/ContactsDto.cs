using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Models
{
    public class ContactsDto
    {
        public int ContactId { get; set; }
        public int AccountId { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public int GenderId { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public short? Country { get; set; }
        public string Email { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string GooglePlus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public short? ContactTypeId { get; set; }
        public int? CampaignId { get; set; }
        public bool? FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        //public Accounts Contact { get; set; }
    }
}
