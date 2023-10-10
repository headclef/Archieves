using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Persistence.Contexts;
using Archieves.Persistence.Repositories.Common;

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
        // Metodlar Buraya
        #endregion
    }
}