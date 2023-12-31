﻿using Archieves.Application.Repositories.Common;
using Archieves.Domain.Entities;

namespace Archieves.Application.Repositories
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Task<Rating> GetByBookIdAsync(int? id);
    }
}