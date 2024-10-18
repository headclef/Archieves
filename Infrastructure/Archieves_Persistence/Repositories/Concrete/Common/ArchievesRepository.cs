using Archieves_Application.Interfaces.Repositories.Abstract.Common;
using Archieves_Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Archieves_Persistence.Repositories.Concrete.Common
{
    public class ArchievesRepository<T> : IArchievesRepository<T> where T : class
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
        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                // Add entity to database
                await _context.Set<T>().AddAsync(entity);
                // Save changes
                await _context.SaveChangesAsync();
                // Return true if success
                return true;
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return false if exception
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                // Update entity in database
                _context.Set<T>().Update(entity);
                // Save changes
                await _context.SaveChangesAsync();
                // Return true if success
                return true;
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return false if exception
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                // Remove entity from database
                _context.Set<T>().Remove(entity);
                // Save changes
                await _context.SaveChangesAsync();
                // Return true if success
                return true;
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
                // Remove entity from database
                _context.Set<T>().Remove(entity);
                // Save changes
                await _context.SaveChangesAsync();
                // Return true if success
                return true;
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

        public async Task<List<T>?> GetAllAsync()
        {
            try
            {
                // Get all entities from database
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return null if exception
                return null;
            }
        }
        #endregion
    }
}