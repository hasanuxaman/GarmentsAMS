using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SQIndustryThree.EntityManager.FGWHDB
{
    public partial class FGWHDbContext : DbContext
    {
        public FGWHDbContext()
            : base("name=FGWHDbContext")
        {
        }

        public virtual DbSet<Tbl_CartonDetails> Tbl_CartonDetails { get; set; }
        public virtual DbSet<Tbl_CartonMaster> Tbl_CartonMaster { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.CartonMasterID)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.CartonNo)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.SizeXS)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.SizeS)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.SizeM)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.SizeL)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.SizeXL)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.SizeXX)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.SizeXXX)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.Quentity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.Net_Weight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.Gross_Weight)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonDetails>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.BuyerID)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.BusinessUnitID)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.PO)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.Style)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.Order_Quty)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.WinShip_Quty)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.Pluse)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.Persentes)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.Total_Carton)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.Dstination)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.Solid_Colour)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.Solid_Size)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.CartonMeasurement)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_CartonMaster>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);
        }
    }
}
