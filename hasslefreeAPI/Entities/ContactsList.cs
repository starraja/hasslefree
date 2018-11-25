using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class ContactsList
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int GenderId { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string OfficePhone { get; set; }
        public string MobileNumber { get; set; }
        public short? ContactTypeId { get; set; }
        public short? ContactAuthority { get; set; }
        public string Source { get; set; }
        public int? ReferenceId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
    }
}
