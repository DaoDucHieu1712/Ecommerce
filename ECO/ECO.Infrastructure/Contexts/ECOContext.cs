using ECO.Domain.Common;
using ECO.Domain.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Contexts
{
    public class ECOContext : IdentityDbContext<AppUser>
    {
        public ECOContext()
        {
        }

        public ECOContext(DbContextOptions<ECOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<DiscountUser> DiscountUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=103.184.112.229,1435; database=ECO;uid=sa;pwd=Abc@123456;";
            optionsBuilder.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Inventory>().HasOne(x => x.Product).WithMany(x => x.Inventories).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.Entity<Inventory>().HasOne(x => x.Color).WithMany(x => x.Inventories).HasForeignKey(x => x.ColorId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.Entity<Inventory>().HasOne(x => x.Size).WithMany(x => x.Inventories).HasForeignKey(x => x.SizeId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<OrderDetail>().HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.Entity<OrderDetail>().HasOne(x => x.Color).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ColorId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.Entity<OrderDetail>().HasOne(x => x.Size).WithMany(x => x.OrderDetails).HasForeignKey(x => x.SizeId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.Entity<OrderDetail>().HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<Rating>().HasOne(x => x.Product).WithMany(x => x.Ratings).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.Entity<Rating>().HasOne(x => x.Customer).WithMany(x => x.Ratings).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<CartItem>().HasOne(x => x.Product).WithMany(x => x.CartItems).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.Entity<CartItem>().HasOne(x => x.Cart).WithMany(x => x.Items).HasForeignKey(x => x.CartId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<DiscountUser>().HasOne(x => x.Customer).WithMany(x => x.DiscountUsers).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.Entity<DiscountUser>().HasOne(x => x.Discount).WithMany(x => x.DiscountUsers).HasForeignKey(x => x.DiscountId).OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<AppRole>()
              .HasData(
              new AppRole { Id = Guid.NewGuid().ToString(), Name = "Admin", Description = "Admin", NormalizedName = "ADMIN" },
              new AppRole { Id = Guid.NewGuid().ToString(), Name = "Staff", Description = "Staff", NormalizedName = "STAFF" },
              new AppRole { Id = Guid.NewGuid().ToString(), Name = "Customer", Description = "Customer", NormalizedName = "CUSTOMER" }
              );

            builder.Entity<Size>().HasData(
                new Size { Id = 1, SizeName = "S" },
                new Size { Id = 2, SizeName = "M" },
                new Size { Id = 3, SizeName = "L" },
                new Size { Id = 4, SizeName = "XL" },
                new Size { Id = 5, SizeName = "2XL" },
                new Size { Id = 6, SizeName = "3XL" },
                new Size { Id = 7, SizeName = "4XL" }
            );
        }

        public override int SaveChanges()
        {
            TrackingEntities();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            TrackingEntities();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void TrackingEntities()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as BaseEntity<int>;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreatedAt = DateTime.Now;
                    }
                    changedOrAddedItem.UpdatedAt = DateTime.Now;
                }
            }
        }

    }
}
