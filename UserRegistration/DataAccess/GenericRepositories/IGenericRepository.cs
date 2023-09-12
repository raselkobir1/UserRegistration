namespace UserRegistration.DataAccess.GenericRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<long> AddAsync(T entity);

    }
}
