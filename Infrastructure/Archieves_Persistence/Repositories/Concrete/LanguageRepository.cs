using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Domain.Entities;
using Archieves_Persistence.Context;
using Archieves_Persistence.Repositories.Concrete.Common;

namespace Archieves_Persistence.Repositories.Concrete
{
    public class LanguageRepository : ArchievesRepository<Language>, ILanguageRepository
    {
        #region Properties
        private readonly ArchievesDbContext _context;
        #endregion
        #region Constructor
        public LanguageRepository(ArchievesDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion
        #region Methods
        // Custom methods for LanguageRepository
        #endregion
    }
}