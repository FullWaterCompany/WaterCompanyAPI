using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class waterComapnyContext : DbContext
    {
        public waterComapnyContext()
        {
        }

        public waterComapnyContext(DbContextOptions<waterComapnyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<RealStateType> RealStateTypes { get; set; } = null!;
        public virtual DbSet<SliceValue> SliceValues { get; set; } = null!;
        public virtual DbSet<Subscriber> Subscribers { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=waterComapny;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AmountConsumption).HasColumnName("Amount_Consumption");

                entity.Property(e => e.ConsumptionValue)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Consumption_Value");

                entity.Property(e => e.CurrentConsumption).HasColumnName("Current_Consumption");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.From)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsThereSanitation).HasColumnName("Is_ There_Sanitation");

                entity.Property(e => e.Notes).HasMaxLength(100);

                entity.Property(e => e.PreviousConsumption).HasColumnName("Previous_Consumption");

                entity.Property(e => e.RealStateType).HasColumnName("realState_Type");

                entity.Property(e => e.ServiceFee)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Service_Fee");

                entity.Property(e => e.SubscriberNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Subscriber_No")
                    .IsFixedLength();

                entity.Property(e => e.SubscriptionNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Subscription_No")
                    .IsFixedLength();

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Tax_Rate");

                entity.Property(e => e.TaxValue)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Tax_Value");

                entity.Property(e => e.To)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate()+(30))");

                entity.Property(e => e.TotalBill)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Total_Bill");

                entity.Property(e => e.TotalInvoice)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Total_Invoice");

                entity.Property(e => e.WastewaterConsumption)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Wastewater_Consumption");

                entity.Property(e => e.Year)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.RealStateTypeNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.RealStateType)
                    .HasConstraintName("FK_Invoice_realState_Type");

                entity.HasOne(d => d.SubscriberNoNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.SubscriberNo)
                    .HasConstraintName("FK_Invoice_Subscriber");

                entity.HasOne(d => d.SubscriptionNoNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.SubscriptionNo)
                    .HasConstraintName("FK_Invoice_Subscription");
            });

            modelBuilder.Entity<RealStateType>(entity =>
            {
                entity.ToTable("realState_Type");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(100);
            });

            modelBuilder.Entity<SliceValue>(entity =>
            {
                entity.ToTable("Slice_values");

                entity.Property(e => e.MaxValue).HasColumnName("Max_Value");

                entity.Property(e => e.MinValue).HasColumnName("Min_Value");

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SanitationPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Sanitation_Price");

                entity.Property(e => e.ValuesCondition).HasColumnName("Values_condition");

                entity.Property(e => e.WaterPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Water_Price");
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.ToTable("Subscriber");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Area).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Notes).HasMaxLength(100);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("Subscription");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsThereSanitation).HasColumnName("Is_There_Sanitation");

                entity.Property(e => e.LastReading).HasColumnName("lastReading");

                entity.Property(e => e.Notes).HasMaxLength(100);

                entity.Property(e => e.RealStateType).HasColumnName("RealState_Type");

                entity.Property(e => e.SubscriberCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Subscriber_Code")
                    .IsFixedLength();

                entity.Property(e => e.UnitNo).HasColumnName("Unit_No");

                entity.HasOne(d => d.RealStateTypeNavigation)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.RealStateType)
                    .HasConstraintName("FK_Subscription_realState_Type");

                entity.HasOne(d => d.SubscriberCodeNavigation)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.SubscriberCode)
                    .HasConstraintName("FK_Subscription_Subscriber");
            });

            modelBuilder.HasSequence<int>("AutoIncrementSequence");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
