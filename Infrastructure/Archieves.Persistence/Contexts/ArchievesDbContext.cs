using Archieves.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archieves.Persistence.Contexts
{
    public class ArchievesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server = FURKANTURAL; Database = ArchievesDb; Integrated Security = True; TrustServerCertificate = True");
            optionsBuilder.UseSqlServer(@"Server = FURKANTURAL; Database = ArchievesDb; Integrated Security = True; TrustServerCertificate = True");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
