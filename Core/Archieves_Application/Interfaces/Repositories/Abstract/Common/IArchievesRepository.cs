namespace Archieves_Application.Interfaces.Repositories.Abstract.Common
{
    public interface IArchievesRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<T?> GetByIdAsync(int id);
        Task<IQueryable<T>?> GetAllAsync();
    }
}