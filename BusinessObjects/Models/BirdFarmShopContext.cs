using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models
{
    public partial class BirdFarmShopContext : DbContext
    {
        public BirdFarmShopContext()
        {
        }

        public BirdFarmShopContext(DbContextOptions<BirdFarmShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bird> Birds { get; set; } = null!;
        public virtual DbSet<TblComment> TblComments { get; set; } = null!;
        public virtual DbSet<TblDistrict> TblDistricts { get; set; } = null!;
        public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;
        public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblTime> TblTimes { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<TblWard> TblWards { get; set; } = null!;
        public virtual DbSet<Tblchildrenbird> Tblchildrenbirds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        public string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:BirdFarmShop"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bird>(entity =>
            {
                entity.ToTable("Bird");

                entity.Property(e => e.BirdId).HasColumnName("BirdID");

                entity.Property(e => e.BirdDescription).HasMaxLength(500);

                entity.Property(e => e.BirdName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WeightofBirds).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Birds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bird__UserID__440B1D61");
            });

            modelBuilder.Entity<TblComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__tblComme__C3B4DFAA147FFC07");

                entity.ToTable("tblComment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.BirdId).HasColumnName("BirdID");

                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.Property(e => e.Content).HasMaxLength(300);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Bird)
                    .WithMany(p => p.TblComments)
                    .HasForeignKey(d => d.BirdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCommen__BirdI__47DBAE45");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCommen__UserI__46E78A0C");
            });

            modelBuilder.Entity<TblDistrict>(entity =>
            {
                entity.HasKey(e => e.DistrictId)
                    .HasName("PK__tblDistr__85FDA4A643D009BC");

                entity.ToTable("tblDistrict");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(5)
                    .HasColumnName("DistrictID");

                entity.Property(e => e.DistrictName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tblOrder__C3905BAFED5FE00C");

                entity.ToTable("tblOrders");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ReasonContent).HasMaxLength(5);

                entity.Property(e => e.TimeId).HasColumnName("TimeID");

                entity.Property(e => e.TypeOrder).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.TimeId)
                    .HasConstraintName("FK__tblOrders__TimeI__4D94879B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrders__UserI__4CA06362");
            });

            modelBuilder.Entity<TblOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tblOrder__C3905BAF908C24ED");

                entity.ToTable("tblOrderDetails");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.BirdId).HasColumnName("BirdID");

                entity.Property(e => e.CostsIncurred).HasMaxLength(50);

                entity.Property(e => e.TimeId).HasColumnName("TimeID");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Bird)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.BirdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrderD__BirdI__5165187F");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.TblOrderDetail)
                    .HasForeignKey<TblOrderDetail>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrderD__Order__5070F446");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__tblRole__8AFACE3A9B186FD9");

                entity.ToTable("tblRole");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(5)
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(15);
            });

            modelBuilder.Entity<TblTime>(entity =>
            {
                entity.HasKey(e => e.TimeId)
                    .HasName("PK__tblTime__E04ED9670CE27244");

                entity.ToTable("tblTime");

                entity.Property(e => e.TimeId).HasColumnName("TimeID");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tblUser__1788CCAC5F9033C4");

                entity.ToTable("tblUser");

                entity.HasIndex(e => e.Email, "UQ__tblUser__A9D105343174A929")
                    .IsUnique();
                entity.Property(e => e.image).HasMaxLength(255);

                entity.HasIndex(e => e.UserName, "UQ__tblUser__C9F28456BCFE7C36")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(5)
                    .HasColumnName("DistrictID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Pass)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasMaxLength(5)
                    .HasColumnName("RoleID");

                entity.Property(e => e.UserAddress).HasMaxLength(250);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WardId)
                    .HasMaxLength(5)
                    .HasColumnName("WardID");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK__tblUser__Distric__3F466844");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUser__RoleID__403A8C7D");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.WardId)
                    .HasConstraintName("FK__tblUser__WardID__412EB0B6");
            });

            modelBuilder.Entity<TblWard>(entity =>
            {
                entity.HasKey(e => e.WardId)
                    .HasName("PK__tblWard__C6BD9BEAD8F51247");

                entity.ToTable("tblWard");

                entity.Property(e => e.WardId)
                    .HasMaxLength(5)
                    .HasColumnName("WardID");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(5)
                    .HasColumnName("DistrictID");

                entity.Property(e => e.WardName).HasMaxLength(50);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.TblWards)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK__tblWard__WardNam__3A81B327");
            });

            modelBuilder.Entity<Tblchildrenbird>(entity =>
            {
                entity.HasKey(e => e.ChildrenBirdId)
                    .HasName("PK__tblchild__9CC08C1A2FCE3CEE");

                entity.ToTable("tblchildrenbird");

                entity.Property(e => e.ChildrenBirdId).HasColumnName("ChildrenBirdID");

                entity.Property(e => e.BirdId).HasColumnName("BirdID");

                entity.Property(e => e.ChildrenBirdName).HasMaxLength(50);

                entity.Property(e => e.ChildrenBirdOfType).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Bird)
                    .WithMany(p => p.Tblchildrenbirds)
                    .HasForeignKey(d => d.BirdId)
                    .HasConstraintName("FK__tblchildr__BirdI__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
