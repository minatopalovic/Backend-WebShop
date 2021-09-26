using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebShopIT28g2017.Entities
{
    public partial class OnlineWardrobeShopContext : DbContext
    {
        public OnlineWardrobeShopContext()
        {
        }

        public OnlineWardrobeShopContext(DbContextOptions<OnlineWardrobeShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderWardrobe> OrderWardrobes { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Wardrobe> Wardrobes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("MATERIAL");

                entity.Property(e => e.MaterialId).HasColumnName("materialID");

                entity.Property(e => e.MaterialName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("materialName");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("MODEL");

                entity.Property(e => e.ModelId).HasColumnName("modelID");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("modelName");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDER_");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.Confirmed).HasColumnName("confirmed");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("orderDate");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("paymentMethod");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDER___userID__22FF2F51");
            });

            modelBuilder.Entity<OrderWardrobe>(entity =>
            {
                entity.HasKey(e => e.OwId)
                    .HasName("PK__ORDER_WA__4F8B66D72D83B873");

                entity.ToTable("ORDER_WARDROBE");

                entity.Property(e => e.OwId).HasColumnName("owID");

                entity.Property(e => e.Orderr).HasColumnName("orderr");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Wardrobe).HasColumnName("wardrobe");

                entity.HasOne(d => d.OrderrNavigation)
                    .WithMany(p => p.OrderWardrobes)
                    .HasForeignKey(d => d.Orderr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDER_WAR__order__25DB9BFC");

                entity.HasOne(d => d.WardrobeNavigation)
                    .WithMany(p => p.OrderWardrobes)
                    .HasForeignKey(d => d.Wardrobe)
                    .HasConstraintName("FK__ORDER_WAR__wardr__26CFC035");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("ratingID");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("comment");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.Property(e => e.Userr).HasColumnName("userr");

                entity.Property(e => e.Wardrobe).HasColumnName("wardrobe");

                entity.HasOne(d => d.UserrNavigation)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.Userr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RATING__userr__29AC2CE0");

                entity.HasOne(d => d.WardrobeNavigation)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.Wardrobe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RATING__wardrobe__2AA05119");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE_");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("SUPPLIER");

                entity.Property(e => e.SupplierId).HasColumnName("supplierID");

                entity.Property(e => e.SupplierAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("supplierAddress");

                entity.Property(e => e.SupplierEmail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("supplierEmail");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("supplierName");

                entity.Property(e => e.SupplierPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("supplierPhoneNumber");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER_");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Rolee).HasColumnName("rolee");

                entity.Property(e => e.Salt)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("salt");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("userAddress");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userFirstName");

                entity.Property(e => e.UserLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userLastName");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("userPassword");

                entity.Property(e => e.UserPhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("userPhoneNumber");

                entity.Property(e => e.UserUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userUserName");

                entity.HasOne(d => d.RoleeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Rolee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USER___rolee__1A69E950");
            });

            modelBuilder.Entity<Wardrobe>(entity =>
            {
                entity.ToTable("WARDROBE");

                entity.Property(e => e.WardrobeId).HasColumnName("wardrobeID");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.InStock).HasColumnName("inStock");

                entity.Property(e => e.MaterialId).HasColumnName("materialID");

                entity.Property(e => e.ModelId).HasColumnName("modelID");

                entity.Property(e => e.StockQuatity).HasColumnName("stockQuatity");

                entity.Property(e => e.SupplierId).HasColumnName("supplierID");

                entity.Property(e => e.WardrobeBrand)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("wardrobeBrand");

                entity.Property(e => e.WardrobeColor)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("wardrobeColor");

                entity.Property(e => e.WardrobeDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("wardrobeDescription");

                entity.Property(e => e.WardrobePicture)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("wardrobePicture");

                entity.Property(e => e.WardrobePrice).HasColumnName("wardrobePrice");

                entity.Property(e => e.WardrobeSize)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("wardrobeSize");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Wardrobes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WARDROBE__catego__1E3A7A34");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Wardrobes)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WARDROBE__materi__1F2E9E6D");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Wardrobes)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WARDROBE__modelI__1D4655FB");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Wardrobes)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WARDROBE__suppli__2022C2A6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
