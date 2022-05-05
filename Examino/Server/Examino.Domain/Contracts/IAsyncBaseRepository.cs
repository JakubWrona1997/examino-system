namespace Examino.Domain.Contracts
{
    public interface IAsyncBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
