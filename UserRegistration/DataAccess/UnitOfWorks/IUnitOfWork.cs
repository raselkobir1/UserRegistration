using UserRegistration.DataAccess.UserRepositories;

namespace UserRegistration.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; } 
    } 
}
