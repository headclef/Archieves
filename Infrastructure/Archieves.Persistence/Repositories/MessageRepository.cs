using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Persistence.Contexts;
using Archieves.Persistence.Repositories.Common;

namespace Archieves.Persistence.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        private readonly ArchievesDbContext _context;
        public MessageRepository(ArchievesDbContext context) : base(context)
        {
            _context = context;
        }
        #region Methods
        // Metodlar Buraya
        #endregion
    }
}
