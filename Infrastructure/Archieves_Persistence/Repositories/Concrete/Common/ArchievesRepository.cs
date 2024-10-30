using Archieves_Application.Interfaces.Repositories.Abstract.Common;
using Archieves_Domain.Entities.Common;
using Archieves_Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Archieves_Persistence.Repositories.Concrete.Common
{
    public class ArchievesRepository<T> : IArchievesRepository<T> where T : ArchievesEntity
    {
        #region Properties
        private readonly ArchievesDbContext _context;
        #endregion
        #region Constructor
        public ArchievesRepository(ArchievesDbContext context)
        {
            _context = context;
            // Set 60 sec timeout for database operations
            _context.Database.SetCommandTimeout(TimeSpan.FromSeconds(60));
        }
        #endregion
        #region Methods
        public async Task<T?> AddAsync(T entity)
        {
            try
            {
                // Add entity to database
                await _context.Set<T>().AddAsync(entity);
                // Save changes
                await _context.SaveChangesAsync();
                // Return entity if success
                return entity;
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return null if exception
                return null;
            }
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            try
            {
                // Untrack entity if tracking
                TrackControl(entity);
                // Track entity
                _context.Attach(entity);
                // Set entity state to modified
                _context.Entry(entity).State = EntityState.Modified;
                // Save changes
                await _context.SaveChangesAsync();
                // Return entity if success
                return entity;
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return null if exception
                return null;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                // Check if entity is null
                if (entity is null)
                    return false;
                // Remove entity from database
                _context.Set<T>().Remove(entity);
                // Save changes and return true if success
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return false if exception
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                // Find entity by id
                var entity = await GetByIdAsync(id);
                // Check if entity is null
                if (entity is null)
                    return false;
                // Remove entity from database
                _context.Set<T>().Remove(entity);
                // Save changes and return true if success
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return false if exception
                return false;
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                // Get entity by id from database
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return null if exception
                return null;
            }
        }

        public async Task<IQueryable<T>?> GetAllAsync()
        {
            try
            {
                // Get all entities from database
                return _context.Set<T>().AsQueryable().AsNoTracking();
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return null if exception
                return null;
            }
        }
        private void TrackControl(T entity)
        {
            // Check if entity is tracking
            bool tracking = _context.ChangeTracker.Entries<T>().Any(x => x.Entity.Id == entity.Id);
            // Detach entity if tracking
            if (tracking)
                _context.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity.Id == entity.Id).State = EntityState.Detached;
        }
        #endregion
    }
}