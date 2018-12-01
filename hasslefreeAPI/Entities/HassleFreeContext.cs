using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace hasslefreeAPI.Entities
{
    public partial class HassleFreeContext : IdentityDbContext
    {

        public HassleFreeContext(DbContextOptions<HassleFreeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Activities> Activities { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Competitors> Competitors { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<ProductList> ProductList { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ReferenceLookup> ReferenceLookup { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("Accounts", "dbo");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountName).IsRequired();

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Employees)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.IndustrySubTypeId).HasColumnName("IndustrySubTypeID");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Turnover)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPhoneAlternate)
                    .HasColumnName("WorkPhone_Alternate")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPhoneMain)
                    .HasColumnName("WorkPhone_Main")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Activities>(entity =>
            {
                entity.HasKey(e => e.ActivityId);

                entity.ToTable("Activities", "dbo");

                entity.Property(e => e.ActivityEndTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ActivityLocation).IsRequired();

                entity.Property(e => e.ActivityStartTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ActivityTitle).IsRequired();

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "dbo");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Landmark).HasMaxLength(100);

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Pincode).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Address_dbo.Accounts_AccountID");
            });

            modelBuilder.Entity<Competitors>(entity =>
            {
                entity.HasKey(e => e.CompetitorId);

                entity.ToTable("Competitors", "dbo");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("Contacts", "dbo");

                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CampaignId).HasColumnName("CampaignID");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactFirstName).IsUnicode(false);

                entity.Property(e => e.ContactLastName).IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Department).IsUnicode(false);

                entity.Property(e => e.Designation).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Facebook)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GooglePlus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Twitter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Contact)
                    .WithOne(p => p.Contacts)
                    .HasForeignKey<Contacts>(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Contacts_dbo.Accounts_AccountID");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.ToTable("Documents", "dbo");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.HasKey(e => e.LeadId);

                entity.ToTable("Leads", "dbo");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyAddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyAddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyAddressLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyPostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyState)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyTurnover)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyWebsite)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.Converted).HasColumnName("CONVERTED");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.IndustrySubTypeId).HasColumnName("IndustrySubTypeID");

                entity.Property(e => e.LeadDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LeadFirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LeadLastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.OpportunityId).HasColumnName("OpportunityID");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_dbo.Leads_dbo.Accounts_AccountID");
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.ToTable("Notes", "dbo");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Notes1)
                    .IsRequired()
                    .HasColumnName("Notes");
            });

            modelBuilder.Entity<ProductList>(entity =>
            {
                entity.ToTable("ProductList", "dbo");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");

                entity.Property(e => e.TaxAmount).HasColumnType("money");

                entity.Property(e => e.Uom).HasColumnName("UOM");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Products", "dbo");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Rate).HasColumnType("money");
            });

            modelBuilder.Entity<ReferenceLookup>(entity =>
            {
                entity.ToTable("ReferenceLookup", "dbo");

                entity.Property(e => e.ReferenceLookupId).HasColumnName("ReferenceLookupID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.SubCategory).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("Employee", "dbo");

                entity.Property(e => e.CreatedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FlagActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.FirstName).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.LastName).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.StaffID).HasMaxLength(100).IsUnicode(false);
                                
            });

        }
    }
}
