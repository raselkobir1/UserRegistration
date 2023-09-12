namespace UserRegistration.DataAccess.GenericRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<long> AddAsync(T entity);
        Task<long> UpdateAsync(T entity);
        Task<long> DeleteAsync(long id, long userId);
    }
}
