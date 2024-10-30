using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Domain.Entities;
using Archieves_Persistence.Context;
using Archieves_Persistence.Repositories.Concrete.Common;

namespace Archieves_Persistence.Repositories.Concrete
{
    public class PublisherRepository : ArchievesRepository<Publisher>, IPublisherRepository
    {
        #region Properties
        private readonly ArchievesDbContext _context;
        #endregion
        #region Constructor
        public PublisherRepository(ArchievesDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion
        #region Methos
        // Custom methods for this LogRepository
        #endregion
    }
}