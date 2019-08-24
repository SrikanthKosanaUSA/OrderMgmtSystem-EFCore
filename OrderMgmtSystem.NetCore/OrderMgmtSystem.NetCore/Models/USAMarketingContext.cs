using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrderMgmtSystem.NetCore.Models
{
    public partial class USAMarketingContext : DbContext
    {
        public USAMarketingContext()
        {
        }

        public USAMarketingContext(DbContextOptions<USAMarketingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblInvoice> TblInvoice { get; set; }
        public virtual DbSet<TblItem> TblItem { get; set; }
        public virtual DbSet<TblLineItem> TblLineItem { get; set; }
        public virtual DbSet<TblSalesPerson> TblSalesPerson { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("tblCustomer");

                entity.HasIndex(e => new { e.Name, e.Phone })
                    .HasName("name_phone_unique")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(48);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(24);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(24);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.ToTable("tblInvoice");

                entity.HasIndex(e => new { e.InvoiceDate, e.Total })
                    .HasName("invoicedate_total_unique")
                    .IsUnique();

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

                entity.Property(e => e.SalesTax).HasColumnType("money");

                entity.Property(e => e.ShipDate).HasColumnType("date");

                entity.Property(e => e.Subtotal).HasColumnType("money");

                entity.Property(e => e.Terms)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblInvoice)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Customer_ID_fk");

                entity.HasOne(d => d.SalesPerson)
                    .WithMany(p => p.TblInvoice)
                    .HasForeignKey(d => d.SalesPersonId)
                    .HasConstraintName("salesperson_ID_fk");
            });

            modelBuilder.Entity<TblItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("tblItem");

                entity.HasIndex(e => e.ItemNumber)
                    .HasName("itemnumber_unique")
                    .IsUnique();

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<TblLineItem>(entity =>
            {
                entity.HasKey(e => e.LineItemId);

                entity.ToTable("tblLineItem");

                entity.Property(e => e.LineItemId).HasColumnName("LineItemID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.TblLineItem)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Invoice_ID_fk");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblLineItem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Item_ID_fk");
            });

            modelBuilder.Entity<TblSalesPerson>(entity =>
            {
                entity.HasKey(e => e.SalesPersonId);

                entity.ToTable("tblSalesPerson");

                entity.HasIndex(e => new { e.Fname, e.Lname })
                    .HasName("fname_lname_unique")
                    .IsUnique();

                entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(24);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(24);
            });
        }
    }
}
