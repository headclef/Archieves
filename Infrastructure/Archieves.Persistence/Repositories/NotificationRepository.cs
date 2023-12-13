using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Persistence.Contexts;
using Archieves.Persistence.Repositories.Common;

namespace Archieves.Persistence.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly ArchievesDbContext _context;
        public NotificationRepository(ArchievesDbContext context) : base(context)
        {
            _context = context;
        }
        #region Methods

        #endregion
    }
}
