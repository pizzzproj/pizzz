using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pizzzproj.Models
{
    public partial class pizzzaDatabaseContext : DbContext
    {
        public virtual DbSet<ItemSizes> ItemSizes { get; set; }
        public virtual DbSet<MenuItems> MenuItems { get; set; }

        // Unable to generate entity type for table 'dbo.MenuItemPrice'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemSizes>(entity =>
            {
                entity.HasKey(e => e.SizeId);

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuItems>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
