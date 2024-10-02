using Archieves.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Archieves.Persistence.Contexts
{
    public class ArchievesDbContext : DbContext
    {
        public ArchievesDbContext(DbContextOptions<ArchievesDbContext> options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Rating>().ToTable("Rating");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Subscriber>().ToTable("Subscriber");
            modelBuilder.Entity<Notification>().ToTable("Notification");
            modelBuilder.Entity<Message>().ToTable("Message");
        }
    }
}
