using CRM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CRM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Entity<Notification>()
                .HasOne<User>(c => c.User)
                .WithMany(o => o.Notifications)
            .HasForeignKey(c => c.UserId);
            */
            /*
            modelBuilder.Entity<User>()
            .HasMany(e => e.Notifications)
            .WithMany(e => e.Users)
            .UsingEntity(
                "NotificationDetails",
                l => l.HasOne(typeof(Notification)).WithMany().HasForeignKey("NotificationId").HasPrincipalKey(nameof(Notification.Id)),
                r => r.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)),
                j => j.HasKey("NotificationId", "UserId"));
            */
        }
    }
}