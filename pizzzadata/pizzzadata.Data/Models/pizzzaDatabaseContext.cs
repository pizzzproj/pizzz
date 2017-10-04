using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pizzzadata.Data.Models
{
    public partial class PizzzaDatabaseContext : DbContext
    {
        public virtual DbSet<ItemSize> ItemSize { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<MenuItemPrice> MenuItemPrice { get; set; }
        public virtual DbSet<PizzzaAdmin> PizzzaAdmin { get; set; }

        public PizzzaDatabaseContext(DbContextOptions<PizzzaDatabaseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemSize>(entity =>
            {
                entity.HasKey(e => e.SizeId);

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuItemPrice>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuItemPrice)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MenuItemPrice_MenuItems");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.MenuItemPrice)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MenuItemPrice_ItemSizes");
            });

            modelBuilder.Entity<PizzzaAdmin>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
