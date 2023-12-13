using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Persistence.Contexts;
using Archieves.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Archieves.Persistence.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        private readonly ArchievesDbContext _context;
        public RatingRepository(ArchievesDbContext archievesDbContext) : base(archievesDbContext)
        {
            _context = archievesDbContext;
        }
        #region Methods
        // Metodlar buraya.
        public async Task<Rating> GetByBookIdAsync(int? id) => await _context.Ratings.FirstOrDefaultAsync(x => x.BookId == id);
        #endregion
    }
}