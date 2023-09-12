using UserRegistration.DataAccess.Entity;
using UserRegistration.DataAccess.GenericRepositories;

namespace UserRegistration.DataAccess.UserRepositories 
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
