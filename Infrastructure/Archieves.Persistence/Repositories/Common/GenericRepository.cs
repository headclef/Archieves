using Archieves.Application.Repositories.Common;
using Archieves.Domain.Entities.Common;
using Archieves.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Archieves.Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ArchievesDbContext _context;
        public GenericRepository(ArchievesDbContext archievesDbContext)
        {
            _context = archievesDbContext;
            _context.Database.SetCommandTimeout(TimeSpan.FromSeconds(300));
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            var result = false;
            if (entity is not null)
            {
                _context.Set<T>().Remove(entity);
                result = await _context.SaveChangesAsync() > 0;
            }
            else { result = false; }
            return result;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            TrackingControl(entity);
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        #region Methods
        private void TrackingControl(T entity)
        {
            bool tracking = _context.ChangeTracker.Entries<T>().Any(x => x.Entity.Id == entity.Id);
            if (tracking)
                _context.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity.Id == entity.Id).State = EntityState.Detached;
        }
        #endregion
    }
}
