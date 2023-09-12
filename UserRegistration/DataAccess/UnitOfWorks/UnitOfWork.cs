using Microsoft.Extensions.Configuration;
using UserRegistration.DataAccess.UserRepositories;

namespace UserRegistration.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        public UnitOfWork(IConfiguration configuration)
        {
                _configuration = configuration;
        }

        private IUserRepository _userRepository;
        public IUserRepository Users => _userRepository ?? new UserRepository(_configuration);

    }
}
