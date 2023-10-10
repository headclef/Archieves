using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Persistence.Contexts;
using Archieves.Persistence.Repositories.Common;

namespace Archieves.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly ArchievesDbContext _context;
        public CommentRepository(ArchievesDbContext archievesDbContext) : base(archievesDbContext)
        {
            _context = archievesDbContext;
        }
        #region Methods
        // Metodlar Buraya
        #endregion
    }
}