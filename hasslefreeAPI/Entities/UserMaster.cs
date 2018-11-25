using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class UserMaster
    {
        public UserMaster()
        {
            AccountMasterCreatedByNavigation = new HashSet<AccountMaster>();
            AccountMasterModifiedByNavigation = new HashSet<AccountMaster>();
            ActivityListCreatedByNavigation = new HashSet<ActivityList>();
            ActivityListModifiedByNavigation = new HashSet<ActivityList>();
            CompetitorListCreatedByNavigation = new HashSet<CompetitorList>();
            CompetitorListModifiedByNavigation = new HashSet<CompetitorList>();
            ContactsListCreatedByNavigation = new HashSet<ContactsList>();
            ContactsListModifiedByNavigation = new HashSet<ContactsList>();
            DocumentListCreatedByNavigation = new HashSet<DocumentList>();
            DocumentListModifiedByNavigation = new HashSet<DocumentList>();
            InverseCreatedByNavigation = new HashSet<UserMaster>();
            InverseModifiedByNavigation = new HashSet<UserMaster>();
            LeadTransactionCreatedByNavigation = new HashSet<LeadTransaction>();
            LeadTransactionModifiedByNavigation = new HashSet<LeadTransaction>();
            MappingInfoCreatedByNavigation = new HashSet<MappingInfo>();
            MappingInfoModifiedByNavigation = new HashSet<MappingInfo>();
            NotesListCreatedByNavigation = new HashSet<NotesList>();
            NotesListModifiedByNavigation = new HashSet<NotesList>();
            PermissionMasterCreatedByNavigation = new HashSet<PermissionMaster>();
            PermissionMasterModifiedByNavigation = new HashSet<PermissionMaster>();
            ProductListCreatedByNavigation = new HashSet<ProductList>();
            ProductListModifiedByNavigation = new HashSet<ProductList>();
            ProductMasterCreatedByNavigation = new HashSet<ProductMaster>();
            ProductMasterModifiedByNavigation = new HashSet<ProductMaster>();
            RoleMasterCreatedByNavigation = new HashSet<RoleMaster>();
            RoleMasterModifiedByNavigation = new HashSet<RoleMaster>();
            RolePermissionCreatedByNavigation = new HashSet<RolePermission>();
            RolePermissionModifiedByNavigation = new HashSet<RolePermission>();
            UserRoleCreatedByNavigation = new HashSet<UserRole>();
            UserRoleModifiedByNavigation = new HashSet<UserRole>();
            UserRoleUser = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime? LastAccessedDateTime { get; set; }
        public string LastAccessedIp { get; set; }
        public string PasswordToken { get; set; }
        public bool Active { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
        public ICollection<AccountMaster> AccountMasterCreatedByNavigation { get; set; }
        public ICollection<AccountMaster> AccountMasterModifiedByNavigation { get; set; }
        public ICollection<ActivityList> ActivityListCreatedByNavigation { get; set; }
        public ICollection<ActivityList> ActivityListModifiedByNavigation { get; set; }
        public ICollection<CompetitorList> CompetitorListCreatedByNavigation { get; set; }
        public ICollection<CompetitorList> CompetitorListModifiedByNavigation { get; set; }
        public ICollection<ContactsList> ContactsListCreatedByNavigation { get; set; }
        public ICollection<ContactsList> ContactsListModifiedByNavigation { get; set; }
        public ICollection<DocumentList> DocumentListCreatedByNavigation { get; set; }
        public ICollection<DocumentList> DocumentListModifiedByNavigation { get; set; }
        public ICollection<UserMaster> InverseCreatedByNavigation { get; set; }
        public ICollection<UserMaster> InverseModifiedByNavigation { get; set; }
        public ICollection<LeadTransaction> LeadTransactionCreatedByNavigation { get; set; }
        public ICollection<LeadTransaction> LeadTransactionModifiedByNavigation { get; set; }
        public ICollection<MappingInfo> MappingInfoCreatedByNavigation { get; set; }
        public ICollection<MappingInfo> MappingInfoModifiedByNavigation { get; set; }
        public ICollection<NotesList> NotesListCreatedByNavigation { get; set; }
        public ICollection<NotesList> NotesListModifiedByNavigation { get; set; }
        public ICollection<PermissionMaster> PermissionMasterCreatedByNavigation { get; set; }
        public ICollection<PermissionMaster> PermissionMasterModifiedByNavigation { get; set; }
        public ICollection<ProductList> ProductListCreatedByNavigation { get; set; }
        public ICollection<ProductList> ProductListModifiedByNavigation { get; set; }
        public ICollection<ProductMaster> ProductMasterCreatedByNavigation { get; set; }
        public ICollection<ProductMaster> ProductMasterModifiedByNavigation { get; set; }
        public ICollection<RoleMaster> RoleMasterCreatedByNavigation { get; set; }
        public ICollection<RoleMaster> RoleMasterModifiedByNavigation { get; set; }
        public ICollection<RolePermission> RolePermissionCreatedByNavigation { get; set; }
        public ICollection<RolePermission> RolePermissionModifiedByNavigation { get; set; }
        public ICollection<UserRole> UserRoleCreatedByNavigation { get; set; }
        public ICollection<UserRole> UserRoleModifiedByNavigation { get; set; }
        public ICollection<UserRole> UserRoleUser { get; set; }
    }
}
