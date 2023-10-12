using Archieves.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Archieves.Persistence.Contexts
{
    public class ArchievesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server = FURKANTURAL; Database = ArchievesDb; Integrated Security = True; TrustServerCertificate = True");
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server = FURKANTURAL; Database = ArchievesDb; Integrated Security = True; TrustServerCertificate = True");
        }
        public ArchievesDbContext() { }   // For migration purposes
        public ArchievesDbContext(DbContextOptions<ArchievesDbContext> options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Rating>().ToTable("Rating");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Subscriber>().ToTable("Subscriber");
        }
    }
}
