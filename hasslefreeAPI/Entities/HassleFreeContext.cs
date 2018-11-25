using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace hasslefreeAPI.Entities
{
    public partial class HassleFreeContext : DbContext
    {
        public HassleFreeContext()
        {
        }

        public HassleFreeContext(DbContextOptions<HassleFreeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountMaster> AccountMaster { get; set; }
        public virtual DbSet<ActivityList> ActivityList { get; set; }
        public virtual DbSet<CompetitorList> CompetitorList { get; set; }
        public virtual DbSet<ContactsList> ContactsList { get; set; }
        public virtual DbSet<DocumentList> DocumentList { get; set; }
        public virtual DbSet<LeadTransaction> LeadTransaction { get; set; }
        public virtual DbSet<MappingInfo> MappingInfo { get; set; }
        public virtual DbSet<NotesList> NotesList { get; set; }
        public virtual DbSet<PermissionMaster> PermissionMaster { get; set; }
        public virtual DbSet<ProductList> ProductList { get; set; }
        public virtual DbSet<ProductMaster> ProductMaster { get; set; }
        public virtual DbSet<RoleMaster> RoleMaster { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountMaster>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.AccountName).IsRequired();

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TurnOver).HasColumnType("money");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.WebSite)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AccountMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountMaster_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.AccountMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountMaster_ModifiedBy");
            });

            modelBuilder.Entity<ActivityList>(entity =>
            {
                entity.HasKey(e => e.ActivityId);

                entity.Property(e => e.ActivityEndTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ActivityStartTime).HasColumnType("smalldatetime");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Km)
                    .HasColumnName("KM")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ActivityListCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityList_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ActivityListModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityList_ModifiedBy");
            });

            modelBuilder.Entity<CompetitorList>(entity =>
            {
                entity.HasKey(e => e.CompetitorId);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CompetitorListCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitorList_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.CompetitorListModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompetitorList_ModifiedBy");
            });

            modelBuilder.Entity<ContactsList>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.Property(e => e.ContactName).IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Department).IsUnicode(false);

                entity.Property(e => e.Designation).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.OfficePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ContactsListCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactsList_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ContactsListModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContactsList_ModifiedBy");
            });

            modelBuilder.Entity<DocumentList>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.DocumentListCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentList_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.DocumentListModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentList_ModifiedBy");
            });

            modelBuilder.Entity<LeadTransaction>(entity =>
            {
                entity.HasKey(e => e.LeadId);

                entity.Property(e => e.Accategory).HasColumnName("ACCategory");

                entity.Property(e => e.BuyerRef)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClosingDate).HasColumnType("smalldatetime");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LeadDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.LeadTransactionCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeadTransaction_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.LeadTransactionModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeadTransaction_ModifiedBy");
            });

            modelBuilder.Entity<MappingInfo>(entity =>
            {
                entity.HasKey(e => e.MappingId);

                entity.Property(e => e.ChildType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ParentType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MappingInfoCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MappingInfo_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.MappingInfoModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MappingInfo_ModifiedBy");
            });

            modelBuilder.Entity<NotesList>(entity =>
            {
                entity.HasKey(e => e.NotesId);

                entity.Property(e => e.NotesId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.NotesDescription).IsRequired();

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.NotesListCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotesList_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.NotesListModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotesList_ModifiedBy");
            });

            modelBuilder.Entity<PermissionMaster>(entity =>
            {
                entity.HasKey(e => e.PermissionId);

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.UielementCode)
                    .IsRequired()
                    .HasColumnName("UIELEMENT_CODE")
                    .HasMaxLength(50);

                entity.Property(e => e.UielementDescription).HasColumnName("UIELEMENT_Description");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PermissionMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermissionMaster_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.PermissionMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermissionMaster_ModifiedBy");
            });

            modelBuilder.Entity<ProductList>(entity =>
            {
                entity.Property(e => e.ProductListId).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxAmount).HasColumnType("money");

                entity.Property(e => e.Uom).HasColumnName("UOM");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProductListCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductList_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ProductListModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductList_ModifiedBy");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductList)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductList_ProductId");
            });

            modelBuilder.Entity<ProductMaster>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.Property(e => e.Uom).HasColumnName("UOM");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ProductMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductMaster_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ProductMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductMaster_ModifiedBy");
            });

            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RoleMasterCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMaster_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.RoleMasterModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMaster_ModifiedBy");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.Property(e => e.RolePermissionId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RolePermissionCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.RolePermissionModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_ModifedBy");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_PermissionId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_RoleId");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastAccessedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.LastAccessedIp)
                    .HasColumnName("LastAccessedIP")
                    .HasMaxLength(15);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_UserMaster_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.InverseModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_UserMaster_ModifiedBy");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserRoleCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_CreatedBy");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.UserRoleModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_ModifiedBy");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_UserId");
            });
        }
    }
}
