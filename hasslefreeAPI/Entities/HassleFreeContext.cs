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

        public virtual DbSet<PermissionMaster> PermissionMaster { get; set; }
        public virtual DbSet<RoleMaster> RoleMaster { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        // Unable to generate entity type for table 'dbo.AccountMaster'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ActivityList'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CompetitorList'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ContactsList'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DocumentList'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.LeadTransaction'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.MappingInfo'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NotesList'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ProductList'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ProductMaster'. Please see the warning messages.

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-BFV957K;Database=hasslefreedev;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
