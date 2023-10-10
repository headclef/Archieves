using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Persistence.Contexts;
using Archieves.Persistence.Repositories.Common;

namespace Archieves.Persistence.Repositories
{
    public class SubscriberRepository : GenericRepository<Subscriber>, ISubscriberRepository
    {
        private readonly ArchievesDbContext _context;
        public SubscriberRepository(ArchievesDbContext archievesDbContext) : base(archievesDbContext)
        {
            _context = archievesDbContext;
        }
        #region Methods
        // Metodlar Buraya
        #endregion
    }
}