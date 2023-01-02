using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreCrud.Models
{
    public partial class APIDbContext : DbContext
    {
        public APIDbContext()
        {
        }

        public APIDbContext(DbContextOptions<APIDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StockDetail> StockDetails { get; set; }
        public virtual DbSet<StockMaster> StockMasters { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PpDetail> PpDetails { get; set; }
        public virtual DbSet<PpMaster> PpMasters { get; set; }
        public virtual DbSet<MachineAllocation> MachineAllocations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=YEAHIA\\YEAHIA; Database=CoreCrud;user id = sa;password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

               // entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__Categor__300424B4");
            });
            modelBuilder.Entity<StockDetail>(entity =>
            {
                entity.ToTable("stock_detail");

                entity.Property(e => e.MasterId).HasColumnName("masterId");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductQty)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Master)
                    .WithMany(p => p.StockDetails)
                    .HasForeignKey(d => d.MasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stock_detail_to_stock_master");
            });

            modelBuilder.Entity<StockMaster>(entity =>
            {
                entity.ToTable("stock_master");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SuppplierId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrnNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ParentId })
                    .HasName("PK__menu__DF2779110CC6099B");

                entity.ToTable("menu");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ParentId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NavUrl)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<PpDetail>(entity =>
            {
                entity.ToTable("pp_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("delivery_date");

                entity.Property(e => e.FmCode).HasColumnName("fmCode");

                entity.Property(e => e.MasterId).HasColumnName("master_id");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Master)
                    .WithMany(p => p.PpDetails)
                    .HasForeignKey(d => d.MasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pp_master_pp_detail");
            });

            modelBuilder.Entity<PpMaster>(entity =>
            {
                entity.ToTable("pp_master");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Buyer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("buyer");

                entity.Property(e => e.Customer)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("customer");

                entity.Property(e => e.Merchandiser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("merchandiser");

                entity.Property(e => e.PpNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ppNo");

                entity.Property(e => e.StyleNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("styleNo");
            });
            modelBuilder.Entity<MachineAllocation>(entity =>
            {
                entity.ToTable("machine_allocation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MachineNo).HasColumnName("machineNo");

                entity.Property(e => e.McDia).HasColumnName("mc_dia");

                entity.Property(e => e.McGg).HasColumnName("mc_gg");

                entity.Property(e => e.OrderQty).HasColumnName("order_qty");

                entity.Property(e => e.PpNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ppNo");

                entity.Property(e => e.Sl)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("sl");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
