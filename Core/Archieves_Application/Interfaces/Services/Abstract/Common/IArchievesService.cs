namespace Archieves_Application.Interfaces.Services.Abstract.Common
{
    public interface IArchievesService<T>
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IQueryable<T>> GetAllAsync();
    }
}