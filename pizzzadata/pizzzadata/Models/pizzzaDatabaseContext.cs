using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace pizzzadata.Models
{
    /*class Order
    {
        string Size { get; set; }
        string Item { get; set; }
    }*/

    public partial class pizzzaDatabaseContext : DbContext
    {
        public virtual DbSet<ItemSize> ItemSizes { get; set; }
        public virtual DbSet<MenuItemPrice> MenuItemPrice { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             if (!optionsBuilder.IsConfigured)
             {
 #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                 optionsBuilder.UseSqlServer(@"Server=tcp:sqlweek1-elijah.database.windows.net,1433;Initial Catalog=pizzzaDatabase;Persist Security Info=False;User ID=sqladmin_elijah;Password=8Vdh17boc8@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
             }
         }*/

        public pizzzaDatabaseContext(DbContextOptions<pizzzaDatabaseContext> options) : base(options)
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

            modelBuilder.Entity<MenuItem>(entity =>
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
