using CRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Notification>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(o => o.Notifications)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<Notification>()
                .HasOne<User>(c => c.User)
                .WithMany(o => o.Notifications)
                .HasForeignKey(c => c.UserId);

        }
    }
}