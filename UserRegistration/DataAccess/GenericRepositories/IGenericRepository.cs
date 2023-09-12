using UserRegistration.DataAccess.Entity;

namespace UserRegistration.DataAccess.GenericRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<long> AddAsync(T entity);
        Task<T> GetByUserName(string id);   

    }
}
