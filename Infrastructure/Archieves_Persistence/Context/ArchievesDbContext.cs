using Archieves_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Archieves_Persistence.Context
{
    public class ArchievesDbContext : DbContext
    {
        #region Properties
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Log> Logs { get; set; }
        #endregion
        #region Constructor
        public ArchievesDbContext(DbContextOptions<ArchievesDbContext> options) : base(options)
        {
            // Will be gotten from appsettings.json
        }
        #endregion
        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Book>().ToTable("Category");
            modelBuilder.Entity<Book>().ToTable("BookCategory");
            modelBuilder.Entity<Book>().ToTable("Author");
            modelBuilder.Entity<Book>().ToTable("Log");
        }
        #endregion
    }
}