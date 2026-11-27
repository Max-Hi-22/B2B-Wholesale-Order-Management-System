using AgentPortalWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentPortalWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agent>().HasIndex(a => a.Phone).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.email).IsUnique();
            modelBuilder.Entity<OrderDetail>().HasIndex(od => new
            {
                od.OrderID,
                od.ItemID
            }).IsUnique();

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Agent)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AgentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Item)
                .WithMany(i => i.OrderDetail)
                .HasForeignKey(od => od.ItemID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
