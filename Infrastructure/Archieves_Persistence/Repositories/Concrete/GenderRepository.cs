﻿using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Domain.Entities;
using Archieves_Persistence.Context;
using Archieves_Persistence.Repositories.Concrete.Common;

namespace Archieves_Persistence.Repositories.Concrete
{
    public class GenderRepository : ArchievesRepository<Gender>, IGenderRepository
    {
        #region Properties
        private readonly ArchievesDbContext _context;
        #endregion
        #region Constructor
        public GenderRepository(ArchievesDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion
        #region Methods
        // Custom methods for GenderRepository
        #endregion
    }
}
